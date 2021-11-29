using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] private bool _obstacle;
        public bool Obstacle
        {
            get => _obstacle;
        }
        void Awake()
        {
            var renderer = GetComponent<SpriteRenderer>();
            var collider = GetComponent<BoxCollider2D>();
            collider.size = new Vector2( renderer.size.x, renderer.size.y );
        }
    }
}
