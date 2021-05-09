using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Usable : Equipable
{
    [SerializeField] protected float _cooldown;
    protected bool _onCooldown = false;

    protected Animator _useAnimation;

    virtual protected void Start()
    {
        _useAnimation = gameObject.GetComponentInChildren<Animator>();
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds( _cooldown );
        _onCooldown = false;
    }

    public virtual void Use()
    {
        if( _onCooldown )
            return;

        StartCoroutine( Cooldown() );
    }

    private void Update()
    {
        if( !IsActive )
            return;
        Vector3 mousePosition = new Vector3( Input.mousePosition.x, Input.mousePosition.y, 12 );
        Vector3 targetPos = Camera.main.ScreenToWorldPoint( mousePosition );
        Vector3 objectPos = transform.position;
        targetPos.x = targetPos.x - objectPos.x;
        targetPos.z = targetPos.z - objectPos.z;

        float angle = Mathf.Atan2( targetPos.x, targetPos.z ) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler( new Vector3( 90, angle, 0 ) ); //fix 90
    }
}
