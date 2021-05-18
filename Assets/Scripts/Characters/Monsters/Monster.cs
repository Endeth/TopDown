using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class Monster : Entity
    {
        [SerializeField] private Sprite[] _otherSprites;
        [SerializeField] private MultiParticles _deathParticles;

        [SerializeField] private float _attackDamage = 1f;
        [SerializeField] private float _attackForce = 10f;

        override protected void Start()
        {
            var renderer = GetComponent<SpriteRenderer>();
            renderer.sprite = _otherSprites[Random.Range( 0, _otherSprites.Length )];
        }

        void OnCollisionEnter( Collision collision )
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if( player && player.IsAlive() )
            {
                Vector3 attackForce = ( collision.contacts[0].point - transform.position ).normalized * _attackForce;
                player.GetHit( _attackDamage, attackForce );
            }
        }

        override protected void Die()
        {
            base.Die();

            gameObject.SetActive( false );
            Instantiate( _deathParticles, transform.position, Quaternion.identity );
        }
    }
}
