using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class Player : Entity
    {
        private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite _deadImage;

        [SerializeField] private Usable _mainUsable;
        [SerializeField] private Transform _mainUsablePosition;
        [SerializeField] private Usable _secondaryUsable;
        [SerializeField] private Transform _secondaryUsablePosition;

        override protected void Awake()
        {
            base.Awake();

            _spriteRenderer = GetComponent<SpriteRenderer>();

            _mainUsable = Instantiate( _mainUsable, _mainUsablePosition );
            _mainUsable.Activated = true;
            _mainUsable.transform.SetParent( transform );

            _secondaryUsable = Instantiate( _secondaryUsable, _secondaryUsablePosition );
            _secondaryUsable.Activated = true;
            _secondaryUsable.transform.SetParent( transform );
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
            _mainUsable.Activated = false;
        }

        public void UseMain()
        {
            _mainUsable.Use();
        }

        public void UseSecondary()
        {
            _secondaryUsable.Use();
        }
    }
}
