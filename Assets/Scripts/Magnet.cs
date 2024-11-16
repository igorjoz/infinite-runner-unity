using MyGame.Powerups;
using UnityEngine;
[CreateAssetMenu(fileName = "Magnet", menuName = "Powerup/Magnet")]
public class Magnet : Powerup
{
    [SerializeField]
    private PowerupStats range;
    public float GetRange() { return range.GetValue(); }
    [SerializeField]
    private PowerupStats speed;
    public float GetSpeed() { return speed.GetValue(); }
}
