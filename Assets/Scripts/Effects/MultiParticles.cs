using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class MultiParticles : MonoBehaviour
    {
        public List<ParticleSystem> ParticleSystems = new List<ParticleSystem>();
        void Start()
        {
            ParticleSystems.ForEach( sys => { sys.transform.localScale = transform.localScale; } );
        }
        public void Update()
        {
            if( !ParticleSystems.Exists( system => system.IsAlive() ) )
                Destroy( gameObject );
        }

    }
}
