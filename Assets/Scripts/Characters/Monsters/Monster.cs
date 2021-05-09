using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private Sprite[] _otherSprites;
    [SerializeField] private MultiParticles _deathParticles;
    [SerializeField] private float _life = 2f;
    [SerializeField] private float _attackForce = 10f;

    private bool _isAlive = true;
    private Fractions.Id _fraction = Fractions.Id.Enemy;
    public bool IsAlive
    {
        get => _isAlive;
    }

    public Fractions.Id Fraction
    {
        get => _fraction;
    }

    void Start()
    {
        var renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = _otherSprites[Random.Range( 0, _otherSprites.Length )];
    }

    void OnCollisionEnter( Collision collision )
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if( player )
        {
            Vector3 dir = collision.contacts[0].point - transform.position;
            player.GetComponent<Rigidbody>().AddForce( dir.normalized * _attackForce );
        }
    }

    public void GetDamage( float damage )
    {
        _life = _life - damage;
        if( _life < 0 )
            Die();
    }

    private void Die()
    {
        _isAlive = false;
        gameObject.SetActive( false );
        Instantiate( _deathParticles, transform.position, Quaternion.identity );
    }
}
