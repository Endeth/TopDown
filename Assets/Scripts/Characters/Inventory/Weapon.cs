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

    public void OnTriggerEnter( Collider collider )
    {
        Monster monster = collider.gameObject.GetComponent<Monster>(); //Use entity or gameObject
        Tile tile = collider.gameObject.GetComponent<Tile>();
        if( IsActive )
        {
            if( monster && monster.Fraction != Owner )
            {
                Vector3 dir = collider.transform.position - transform.position;
                monster.GetDamage( _damage );
                monster.GetComponent<Rigidbody>().AddForce( dir.normalized * _force );
            }
            else if( tile && tile.NonPassable )
            {
                _useAnimation.Play( "Idle" );
            }
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
