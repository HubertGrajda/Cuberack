using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PowerUp", menuName = "Effects/DamageBuff")]
public class Damage_Effect : PowerUpEffect
{
    
    public override void ApplyEffect(GameObject player)
    {
        player.GetComponent<PlayerAttack>().projectileType++;
        Debug.Log("better Projectile");
    }

    
}
