using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame.Powerups
{
    public abstract class Powerup : ScriptableObject
    {
        public bool isActive;
        [SerializeField]
        protected PowerupStats duration;
        public float GetDuration() { return duration.GetValue(); }

    }
}