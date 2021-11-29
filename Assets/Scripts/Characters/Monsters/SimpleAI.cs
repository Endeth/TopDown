using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class SimpleAI : Behaviour
    {
        [Tooltip( "Looks for player by default." )] private Player _target;

        void Awake()
        {
            _owner = GetComponent<Monster>();
            _ownerStats = _owner.GetStats();

            if( !_target )
                _target = FindObjectOfType( typeof( Player ) ) as Player;
        }

        void FixedUpdate()
        {
            if( ( _owner.GetSpeed() >= _ownerStats._maxSpeed ) || !Activated )
                return;

            Vector2 targetPosDirection = ( _target.transform.position - transform.position ).normalized;
            //_owner.MovePosition( targetPosDirection * _ownerStats._speed * Time.fixedDeltaTime );
        }
    }
}
