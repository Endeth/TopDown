using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollision : MonoBehaviour
{
    void OnCollisionEnter( Collision collision )
    {
        var weapon = gameObject.GetComponentInParent<Weapon>();
        weapon.OnCollision( collision );
    }
}
