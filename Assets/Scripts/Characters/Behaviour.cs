using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class Behaviour : MonoBehaviour
    {
        protected Entity _owner;
        protected Stats _ownerStats;
        public bool Activated { get; set; }

    }
}
