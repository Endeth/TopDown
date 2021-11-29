using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class Gun : Usable
    {
        [SerializeField] public float _damage = 1.0f;
        [SerializeField] public float _force = 100.0f;

        [SerializeField] private Transform _muzzle;
        [SerializeField] private Projectile _bullet;
        //[SerializeField] private SingleAnimation FireAnimation;

        override protected void Start()
        {
            base.Start();
            Owner = Fractions.Id.Player;
        }

        override public bool Use()
        {
            bool used = base.Use();
            if( used )
            {
                Instantiate( _bullet, transform.position, transform.rotation );
            }
            return used;
        }
    }
}
