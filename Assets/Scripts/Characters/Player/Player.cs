using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private int _health = 3;
    [SerializeField] private float _playerSpeed = 10.0f;
    [SerializeField] private float _maxSpeed = 5.0f;

    [SerializeField] private Sprite _deadImage;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody _rigidbody;

    private bool _isAlive = true;
    private Fractions.Id _fraction = Fractions.Id.Player;
    private Vector3 _movement;

    private Vector3 _mainUsablePosition = new Vector3( 1.5f, 0, 0 ); //could change it to transform to edit in prefab
    //[SerializeField] Transform _mainUsablePosition;
    [SerializeField] private Usable _mainUsable;
    private Usable _secondaryUsable;

    public bool IsAlive
    {
        get => _isAlive;
    }
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody>();

        _mainUsable = Instantiate( _mainUsable, transform );
        _mainUsable.IsActive = true;
        _mainUsable.transform.SetParent( transform );
        _mainUsable.transform.position += _mainUsablePosition;
    }

    void GetHit()
    {
        _health -= 1;
        if( _health == 0 )
            Die();
        else
            EventManager.TriggerEvent( Events.Type.PlayerHit );
    }

    void Die()
    {
        EventManager.TriggerEvent( Events.Type.Death );

        _isAlive = false;
        _spriteRenderer.sprite = _deadImage;
        _mainUsable.IsActive = false;
    }

    void OnCollisionEnter( Collision collision )
    {
        Monster monster = collision.gameObject.GetComponent<Monster>();
        if( monster && _isAlive )
        {
            GetHit();
        }
    }

    void Update()
    {
        if( !_isAlive )
            return;

        if( Input.GetMouseButtonDown( 0 ) )
            _mainUsable.Use();
        //if( Input.GetMouseButtonDown( 1 ) )
        //_secondaryUsable?.Use();

        _movement = new Vector3( Input.GetAxis( "Horizontal" ), 0, Input.GetAxis( "Vertical" ) ).normalized;
        //transform.position += _movement * Time.deltaTime * _playerSpeed;
    }

    void FixedUpdate()
    {
        if( !_isAlive )
            return;

        //_rigidbody.AddForce( _movement * _playerSpeed,ForceMode.Acceleration );
        transform.position += _movement * Time.fixedDeltaTime * _playerSpeed;
    }
}
