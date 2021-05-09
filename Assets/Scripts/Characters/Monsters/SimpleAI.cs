using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    private Player _target;
    private Rigidbody _rigidbody;

    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _maxSpeed = 5.0f;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _target = FindObjectOfType( typeof( Player ) ) as Player;
    }

    void Update()
    {
        //Vector3 target = ( _target.transform.position - transform.position ).normalized;
        //transform.position += target * _speed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        if( _rigidbody.velocity.magnitude >= _maxSpeed )
            return;

        Vector3 target = ( _target.transform.position - transform.position ).normalized;
        _rigidbody.AddForce( target * _speed * 2 );
        //transform.position += target * _speed * Time.fixedDeltaTime;
    }
}
