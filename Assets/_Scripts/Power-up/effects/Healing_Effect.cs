using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PowerUp", menuName = "Effects/HealthBuff")]
public class Healing_Effect : PowerUpEffect
{
    public uint healingAmount;
    public override void ApplyEffect(GameObject player)
    {
        Debug.Log("Player Healed");
        player.GetComponent<PlayerHealth>().Heal(healingAmount);
    }
}
