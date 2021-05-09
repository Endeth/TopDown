using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTextOnEvent : MonoBehaviour
{
    [SerializeField] private Events.Type eventName;

    void OnEnable()
    {
        EventManager.StartListening( eventName, ShowText );
    }

    void OnDisable()
    {
        EventManager.StopListening( eventName, ShowText );
    }

    void ShowText()
    {
        var text = GetComponent<Text>();
        text.enabled = true;
    }
}
