using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

namespace TopDown
{
    public class Usable : Equipable
    {
        [SerializeField] protected float _cooldown;
        protected bool _onCooldown = false;

        protected Animator _useAnimation;
        protected AudioSource _audioSource;

        virtual protected void Start()
        {
            _useAnimation = gameObject.GetComponentInChildren<Animator>();
            _audioSource = gameObject.GetComponentInChildren<AudioSource>();
        }

        private IEnumerator Cooldown()
        {
            yield return new WaitForSeconds( _cooldown );
            _onCooldown = false;
        }

        public virtual bool Use()
        {
            if( _onCooldown )
                return false;

            _audioSource.Play();
            _onCooldown = true;
            StartCoroutine( Cooldown() );
            return true;
        }

        private void Update()
        {
            if( !Activated )
                return;
            Vector3 mousePosition = new Vector3( Input.mousePosition.x, Input.mousePosition.y, 0 );
            Vector3 targetPos = Camera.main.ScreenToWorldPoint( mousePosition );
            Vector3 objectPos = transform.position;
            targetPos.x = targetPos.x - objectPos.x;
            targetPos.y = targetPos.y - objectPos.y;

            float angle = Mathf.Atan2( targetPos.x, targetPos.y ) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler( new Vector3( 0, 0, -angle ) ); //fix 90
        }
    }
}
