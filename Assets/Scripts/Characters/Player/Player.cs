using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class Player : Entity
    {
        //[SerializeField] private float _health = 3;
        //[SerializeField] private float _playerSpeed = 200.0f;

        private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite _deadImage;

        [SerializeField] private Usable _mainUsable;

        override protected void Awake()
        {
            base.Awake();

            _spriteRenderer = GetComponent<SpriteRenderer>();

            _mainUsable = Instantiate( _mainUsable, transform );
            _mainUsable.IsActive = true;
            _mainUsable.transform.SetParent( transform );
        }

        override public void GetHit( float damage, Vector3 force )
        {
            base.GetHit( damage, force );

            EventManager.TriggerEvent( Events.Type.PlayerHit );
        }

        override protected void Die()
        {
            base.Die();

            EventManager.TriggerEvent( Events.Type.Death );

            _spriteRenderer.sprite = _deadImage;
            _mainUsable.IsActive = false;
        }

        public void UseMain()
        {
            _mainUsable.Use();
        }

    }
}
