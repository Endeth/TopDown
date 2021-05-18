using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TopDown
{
    public class ShowTextOnEvent : MonoBehaviour
    {
        [SerializeField] private Events.Type _eventName;

        void OnEnable()
        {
            EventManager.StartListening( _eventName, ShowText );
        }

        void OnDisable()
        {
            EventManager.StopListening( _eventName, ShowText );
        }

        void ShowText()
        {
            var text = GetComponent<Text>();
            //text.enabled = true; //enabling seems quite slow (due to rendering afaik)
            var col = text.color;
            col.a = 1f;
            text.color = col;
        }
    }
}
