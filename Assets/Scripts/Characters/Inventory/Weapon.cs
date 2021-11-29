using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class Weapon : Usable
    {
        public float _damage;
        public float _force;
        public BoxCollider _collider; //TODO delete

        override protected void Start()
        {
            base.Start();
            Owner = Fractions.Id.Player;
            _collider = gameObject.GetComponentInChildren<BoxCollider>();
        }

        public void OnTriggerEnter( Collider collider )
        {
            Entity entity = collider.gameObject.GetComponent<Monster>();
            Tile tile = collider.gameObject.GetComponent<Tile>();
            if( Activated )
            {
                if( entity && entity.GetFraction() != Owner && entity.IsAlive() )
                {
                    Vector3 force = ( collider.transform.position - transform.position ).normalized * _force;
                    entity.GetHit( _damage, force );
                }
                else if( tile && tile.Obstacle )
                {
                    _useAnimation.Play( "Idle" );
                }
            }
        }

        override public bool Use()
        {
            bool used = base.Use();
            if( used )
            {
                _useAnimation.SetTrigger( "Use" );
            }
            return used;
        }
    }
}
