using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class Equipable : MonoBehaviour
    {
        public Fractions.Id Owner { get; set; }
        public bool Activated { get; set; }
    }
}
