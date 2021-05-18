using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class FollowMouse : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        void Update()
        {
            Vector3 mousePosition = new Vector3( Input.mousePosition.x, Input.mousePosition.y, 12 );
            Vector3 mouseWorldPosition = _camera.ScreenToWorldPoint( mousePosition );
            transform.position = new Vector3( mouseWorldPosition.x, transform.position.y, mouseWorldPosition.z );
        }
    }
}
