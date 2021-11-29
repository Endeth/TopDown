using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    [CreateAssetMenu( menuName = "TopDown/Entities/Stats" )]
    public class Stats : ScriptableObject
    {
        // ### SURVIVABILITY ###
        public float _maxHealth;
        //public float _armor;
        //public float _fireResist;

        // ### DAMAGE ###
        //public float _weapondDamageAdd;
        //public float _weaponDamageMultiplier ;
        //public float _fireDamageAdd;
        //public float _fireDamageMultiplier;

        // ### MOVEMENT ###
        public float _speed;
        public float _maxSpeed;

        // ### UTILITY ###
        //public float _experience;
        //public float _experienceMultiplier;
        //public float _itemFindMultiplier;
    }
}
