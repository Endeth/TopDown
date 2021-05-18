using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class WeaponCollision : MonoBehaviour
    {
        //Exists as separate from weapon due to main script being outside of collider, will be removed when hands and player rotation will work correctly
        void OnTriggerEnter( Collider collider )
        {
            var weapon = gameObject.GetComponentInParent<Weapon>();
            weapon.OnTriggerEnter( collider );
        }
    }
}
