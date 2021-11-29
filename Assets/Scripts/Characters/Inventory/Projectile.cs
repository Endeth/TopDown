using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class Projectile : MonoBehaviour
    {
        public Fractions.Id Owner { get; set; }
        [SerializeField] private SingleAnimation _onHitEffect;
        [SerializeField] private Gun _parentWeapon;
        [SerializeField] public float _lifetime = 5.0f;
        [SerializeField] public float _speed = 5.0f;

        [SerializeField] public AudioClip _entityOnHit;
        [SerializeField] public AudioClip _obstacleOnHit;


        private IEnumerator _autoTerminateCoroutine;
        private IEnumerator SelfTerminate()
        {
            yield return new WaitForSeconds( _lifetime );
            Destroy( gameObject );
        }

        void Start()
        {
            _autoTerminateCoroutine = SelfTerminate();
            StartCoroutine( _autoTerminateCoroutine );
        }

        public void OnTriggerEnter( Collider collider )
        {
            Entity entity = collider.gameObject.GetComponent<Monster>();
            Tile tile = collider.gameObject.GetComponent<Tile>();

            bool targetHit = false;

            if( entity && entity.GetFraction() != Owner && entity.IsAlive() )
            {
                Vector3 force = ( collider.transform.position - transform.position ).normalized * _parentWeapon._force;
                entity.GetHit( _parentWeapon._damage, force );
                _onHitEffect.Audio.clip = _entityOnHit;
                targetHit = true;
            }
            else if( tile && tile.Obstacle )
            {
                _onHitEffect.Audio.clip = _obstacleOnHit;
                targetHit = true;
            }

            if( targetHit )
            {
                Instantiate( _onHitEffect, transform.position, transform.rotation );
                StopCoroutine( _autoTerminateCoroutine );
                Destroy( gameObject );
            }
        }

        void Update()
        {
            Vector3 currentPos = transform.position;
            Vector3 direction = transform.TransformDirection( 0, 1, 0 );
            currentPos += direction * _speed * Time.deltaTime;
            transform.position = currentPos;
        }
    }
}
