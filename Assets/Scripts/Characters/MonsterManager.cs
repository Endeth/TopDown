using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class MonsterManager : MonoBehaviour, Observable<Monster>
    {
        private List<Monster> _monsters = new List<Monster>();
        private List<Observer<Monster>> _observers = new List<Observer<Monster>>(); //Kinda weird, I don't think this gives good context - where to notify? Each monster? Each monster what? Kill? Spawn? Dmg? Maybe specific observers would be fine

        public void Attach( Observer<Monster> observer )
        {
            if( !_observers.Contains( observer ) )
                _observers.Add( observer );
        }
        public void Detach( Observer<Monster> observer )
        {
            if( _observers.Contains( observer ) )
                _observers.Remove( observer );
        }
        public void DetachAll()
        {
            _observers.Clear();
        }

        void Awake()
        {
            _monsters.AddRange( GetComponentsInChildren<Monster>() );
        }

        void Start()
        {
            _monsters.ForEach( monster => monster.Wake() );
        }

        public void HandleDeath( Monster deadMonster )
        {
            _monsters.Remove( deadMonster );
            _observers.ForEach( obs => obs.HandleEvent( deadMonster ) );
        }
    }
}
