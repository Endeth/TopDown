using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipable : MonoBehaviour
{
    public Fractions.Id Owner { get; set; }
    public bool IsActive { get; set; }
}
