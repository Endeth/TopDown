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
            var collider = GetComponent<BoxCollider>();
            collider.size = new Vector3( renderer.size.x, renderer.size.y, collider.size.z );
        }
    }
}
