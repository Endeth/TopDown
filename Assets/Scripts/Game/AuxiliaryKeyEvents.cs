using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class AuxiliaryKeyEvents : MonoBehaviour
    {
        void Update()
        {
            if( Input.GetKey( "escape" ) )
            {
                Application.Quit();
            }
        }
    }
}
