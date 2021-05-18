using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class Controller : Behaviour
    {
        private Vector3 _sampledMovement;

        void Awake()
        {
            _owner = GetComponent<Player>();
            _ownerStats = _owner.GetStats();
            _active = true;
        }

        void Update()
        {
            if( !_owner.IsAlive() )
                return;

            if( Input.GetMouseButtonDown( 0 ) )
                ( _owner as Player ).UseMain();

            _sampledMovement = new Vector3( Input.GetAxis( "Horizontal" ), 0, Input.GetAxis( "Vertical" ) ).normalized;
            //_rigidbody.AddForce( _movement * _playerSpeed, ForceMode.Acceleration );
            //transform.position += _movement * Time.deltaTime * _playerSpeed;    }
        }

        void FixedUpdate()
        {
            if( !_owner.IsAlive() )
                return;

            //transform.position += _movement * Time.fixedDeltaTime * _playerSpeed;
            _owner.AddForce( _sampledMovement * _ownerStats._speedForce );
        }
    }
}