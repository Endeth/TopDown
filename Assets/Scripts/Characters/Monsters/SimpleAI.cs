using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class SimpleAI : Behaviour
    {
        [Tooltip( "Looks for player by default." )] private Player _target;

        void Activate()
        {
            _active = true;
        }

        void Awake()
        {
            _owner = GetComponent<Monster>();
            _ownerStats = _owner.GetStats();

            if( !_target )
                _target = FindObjectOfType( typeof( Player ) ) as Player;
        }

        void Start()
        {
            EventManager.StartListening( Events.Type.GameStart, Activate );

        }
        void OnDisable()
        {
            EventManager.StopListening( Events.Type.GameStart, Activate );
        }

        void FixedUpdate()
        {
            if( ( _owner.GetSpeed() >= _ownerStats._maxSpeed ) || !_active )
                return;

            Vector3 targetPosDirection = ( _target.transform.position - transform.position );
            _owner.AddForce( targetPosDirection * _ownerStats._speedForce );
        }
    }
}
