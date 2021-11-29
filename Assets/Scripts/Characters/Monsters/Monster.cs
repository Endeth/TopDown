using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class Monster : Entity
    {
        [SerializeField] private Sprite[] _livingSprites;
        [SerializeField] private Sprite[] _deadSprites; //TODO make living/dead related
        [SerializeField] private SingleAnimation _deathParticles;

        [SerializeField] private float _attackDamage = 1f;
        [SerializeField] private float _attackForce = 10f;

        private int _spriteVersion;
        private Behaviour _behaviour;
        private SpriteRenderer _renderer;
        private MonsterManager _manager;

        public override void Wake()
        {
            _behaviour.Activated = true;
        }

        override protected void Awake()
        {
            base.Awake();
            _renderer = GetComponent<SpriteRenderer>();
            _spriteVersion = Random.Range( 0, _livingSprites.Length );
            _renderer.sprite = _livingSprites[_spriteVersion];
            _behaviour = GetComponent<Behaviour>();
            _manager = GetComponentInParent<MonsterManager>();
        }

        void OnCollisionEnter( Collision collision )
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if( IsAlive() && player && player.IsAlive() )
            {
                Vector3 attackForce = ( collision.contacts[0].point - transform.position ).normalized * _attackForce;
                player.GetHit( _attackDamage, attackForce );

                AudioClip clip = Utility.GetRandomSound( _audioOnAttack );
                if( clip )
                {
                    _audioSource.clip = clip;
                    _audioSource.Play();
                }
            }
        }

        override protected void Die()
        {
            base.Die();

            //gameObject.SetActive( false );
            _manager.HandleDeath( this );
            _behaviour.Activated = false;
            _renderer.sprite = _deadSprites[_spriteVersion];
            Instantiate( _deathParticles, transform.position, Quaternion.identity );
        }
    }
}
