using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private bool _nonPassable;
    public bool NonPassable
    {
        get => _nonPassable;
    }
    void Awake()
    {
        var renderer = GetComponent<SpriteRenderer>();
        var collider = GetComponent<BoxCollider>();
        collider.size = new Vector3( renderer.size.x, renderer.size.y, collider.size.z );
    }
}
