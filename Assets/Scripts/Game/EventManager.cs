using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    private Dictionary<Events.Type, UnityEvent> _events;

    private static EventManager eventManager;
    public static EventManager Instance
    {
        get
        {
            if(!eventManager)
            {
                eventManager = FindObjectOfType( typeof( EventManager ) ) as EventManager;

                if(!eventManager)
                {
                    Debug.LogError( "No instance of EventManager detected" );
                }
                else
                {
                    eventManager.Init();
                }

            }

            return eventManager;
        }
    }

    void Init()
    {
        _events = new Dictionary<Events.Type, UnityEvent>();
    }

    public static void StartListening( Events.Type eventName, UnityAction listener )
    {
        UnityEvent thisEvent;
        if( Instance._events.TryGetValue( eventName, out thisEvent ) )
        {
            thisEvent.AddListener( listener );
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener( listener );
            Instance._events.Add( eventName, thisEvent );
        }
    }

    public static void StopListening( Events.Type eventName, UnityAction listener )
    {
        if( !eventManager )
            return;
        UnityEvent thisEvent;
        if( Instance._events.TryGetValue( eventName, out thisEvent ) )
        {
            thisEvent.RemoveListener( listener );
        }
    }

    public static void TriggerEvent( Events.Type eventName )
    {
        UnityEvent thisEvent;
        if( Instance._events.TryGetValue( eventName, out thisEvent ) )
        {
            thisEvent.Invoke();
        }
    }
}
