using MyGame.Powerups;
using UnityEngine;

namespace MyGame.Powerups
{
    [CreateAssetMenu(fileName = "Immortality", menuName = "Powerup/Immortality")]
    public class Immortality : Powerup
    {
        [SerializeField]
        private PowerupStats speedBoost;
        public float GetSpeedBoost() { return speedBoost.GetValue(); }
    }
}
