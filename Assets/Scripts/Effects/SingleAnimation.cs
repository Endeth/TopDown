using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class SingleAnimation : MonoBehaviour
    {
        public List<ParticleSystem> ParticleSystems = new List<ParticleSystem>();
        public AudioSource Audio;
        void Start()
        {
            ParticleSystems.ForEach( sys => { sys.transform.localScale = transform.localScale; } );
            Audio.Play();
        }
        public void Update()
        {
            if( !ParticleSystems.Exists( system => system.IsAlive() ) && !Audio.isPlaying )
                Destroy( gameObject );
        }

    }
}
