using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class KillSpecificMonsters : Objective<Monster, bool>
    {
        [SerializeField] private List<Monster> _monstersToKill = new List<Monster>();

        public override void HandleEvent( Monster eventParams )
        {
            _monstersToKill.Remove( eventParams );
            if( _monstersToKill.Count == 0 )
            {
                _observers.ForEach( obs => obs.HandleEvent( true ) );
                DetachAll();
            }
        }
    }
}
