using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class Entity : MonoBehaviour
    {
        [SerializeField] protected Fractions.Id _fraction = Fractions.Id.Neutral;
        [SerializeField] protected Stats _stats;
        private float _currentHealth;
        protected bool _isAlive = true;
        protected Rigidbody _rigidbody;

        public Fractions.Id GetFraction() => _fraction;
        public Stats GetStats() => _stats;
        public bool IsAlive() => _isAlive;

        public float GetSpeed()
        {
            return _rigidbody.velocity.magnitude;
        }

        virtual public void GetHit( float damage, Vector3 force )
        {
            _currentHealth -= damage;
            _rigidbody.AddForce( force );
            if( _currentHealth <= 0 )
                Die();
        }

        virtual protected void Die()
        {
            _isAlive = false;
        }
        public void AddForce( Vector3 force )
        {
            _rigidbody.AddForce( force, ForceMode.Acceleration );
        }

        virtual protected void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
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
