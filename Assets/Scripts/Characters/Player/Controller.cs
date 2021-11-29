using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class Controller : Behaviour
    {
        private Vector2 _sampledMovement = new Vector2();

        void Awake()
        {
            _owner = GetComponent<Player>();
            _ownerStats = _owner.GetStats();
            Activated = true;
        }

        void Update()
        {
            if( !_owner.IsAlive() )
                return;

            if( Input.GetMouseButtonDown( 0 ) )
                ( _owner as Player ).UseMain();

            if( Input.GetMouseButtonDown( 1 ) )
                ( _owner as Player ).UseSecondary();

            _sampledMovement.x = Input.GetAxis( "Horizontal" );
            _sampledMovement.y = Input.GetAxis( "Vertical" );
            Debug.Log( "SampledMovement: " + _sampledMovement );
            _sampledMovement.Normalize();
        }

        void FixedUpdate()
        {
            if( !_owner.IsAlive() )
                return;

            _sampledMovement.x = _sampledMovement.x * _ownerStats._speed * Time.fixedDeltaTime + transform.position.x;
            _sampledMovement.y = _sampledMovement.y * _ownerStats._speed * Time.fixedDeltaTime + transform.position.y;
            //Debug.Log( "SampledMovement + current position: " + _sampledMovement );
            _owner.MovePosition( _sampledMovement );
        }
    }
}