using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Usable
{
    public float _damage;
    public float _force;
    public BoxCollider _collider;

    override protected void Start()
    {
        base.Start();
        Owner = Fractions.Id.Player;
        _collider = gameObject.GetComponentInChildren<BoxCollider>();
    }

    public void OnCollision( Collision collision )
    {
        Monster monster = collision.gameObject.GetComponent<Monster>();
        if( IsActive && monster && monster.Fraction != Owner )
        {
            Vector3 dir = collision.contacts[0].point - transform.position;
            monster.GetDamage( _damage );
            monster.GetComponent<Rigidbody>().AddForce( dir.normalized * _force );
        }
    }

    override public void Use()
    {
        base.Use();
        if( !_onCooldown )
        {
            _useAnimation.SetTrigger( "Use" );
            _onCooldown = true;
        }
    }
}
