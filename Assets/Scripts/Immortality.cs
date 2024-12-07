using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Immortality", menuName = "Powerup/Immortality")]
public class Immortality : Powerup
{
    [SerializeField]
    protected PowerupStats speedBoost;

    public float GetSpeedBoost()
    {
        return speedBoost.GetValue(currentLevel);
    }
}
