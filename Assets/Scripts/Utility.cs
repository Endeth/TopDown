using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class Utility
    {
        static public AudioClip GetRandomSound( List<AudioClip> source )
        {
            AudioClip clip = null;
            if( source.Count > 0 )
                clip = source[Random.Range( 0, source.Count )];

            return clip;
        }
    }
}
