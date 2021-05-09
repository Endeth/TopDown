using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollision : MonoBehaviour
{
    void OnTriggerEnter( Collider collider )
    {
        var weapon = gameObject.GetComponentInParent<Weapon>();
        weapon.OnTriggerEnter( collider );
    }
}
