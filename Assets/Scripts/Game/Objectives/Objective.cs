using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    //Objective might be better simply as a child of LevelController
    public abstract class Objective<ObjectiveOf, ObjectiveSubject> : MonoBehaviour, Observer<ObjectiveOf>, Observable<ObjectiveSubject>
    {
        protected List<Observer<ObjectiveSubject>> _observers = new List<Observer<ObjectiveSubject>>();

        public void Attach( Observer<ObjectiveSubject> observer )
        {
            if( !_observers.Contains( observer ) )
                _observers.Add( observer );
        }
        public void Detach( Observer<ObjectiveSubject> observer )
        {
            if( _observers.Contains( observer ) )
                _observers.Remove( observer );
        }
        public void DetachAll()
        {
            _observers.Clear();
        }
        abstract public void HandleEvent( ObjectiveOf eventParams );
    }
}
