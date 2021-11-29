using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class Entity : MonoBehaviour
    {
        [SerializeField] protected Fractions.Id _fraction = Fractions.Id.Neutral;
        [SerializeField] protected Stats _stats;
        [SerializeField] protected List<AudioClip> _audioOnHit = new List<AudioClip>();
        [SerializeField] protected List<AudioClip> _audioOnAttack = new List<AudioClip>();
        [SerializeField] protected List<AudioClip> _audioOnDeath = new List<AudioClip>();

        private float _currentHealth;
        protected bool _isAlive = true;

        protected Rigidbody2D _rigidbody;
        protected AudioSource _audioSource;

        public Fractions.Id GetFraction() => _fraction;
        public Stats GetStats() => _stats;
        public float GetSpeed() => _rigidbody.velocity.magnitude;
        public bool IsAlive() => _isAlive;

        virtual public void Wake()
        {

        }

        virtual public void GetHit( float damage, Vector3 force )
        {
            _currentHealth -= damage;
            _rigidbody.AddForce( force );
            if( _currentHealth <= 0 )
            {
                Die();
            }
            else
            {
                AudioClip clip = Utility.GetRandomSound( _audioOnHit );
                if( clip )
                {
                    _audioSource.clip = clip;
                    _audioSource.Play();
                }
            }
        }

        virtual protected void Die()
        {
            _isAlive = false;

            AudioClip clip = Utility.GetRandomSound( _audioOnDeath );
            if( clip )
            {
                _audioSource.clip = clip;
                _audioSource.Play();
            }
        }
        public void MovePosition( Vector2 movement )
        {
            _rigidbody.MovePosition( movement );
        }

        virtual protected void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _audioSource = GetComponent<AudioSource>();
            _currentHealth = _stats._maxHealth;
        }

        virtual protected void Start()
        {
        }

        virtual protected void Update()
        {

        }
    }
}
