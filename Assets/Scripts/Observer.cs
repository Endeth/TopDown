using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TopDown
{
    public interface Observer<T>
    {
        public void HandleEvent( T eventParams );
    }

    public interface Observable<T>
    {
        public void Attach( Observer<T> observer );
        public void Detach( Observer<T> observer );
        public void DetachAll();
    }
}
