using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PowerUp", menuName = "Effects/SpeedBuff")]
public class Speed_Effect : PowerUpEffect
{
    [SerializeField] private float speedBoostAmount;
    [SerializeField] private float speedBoostTime;
    public override void ApplyEffect(GameObject player)
    {
        Debug.Log("Player Zoomin!");
        player.GetComponent<PlayerMovement>().SpeedBoostInit(speedBoostAmount, speedBoostTime);  //StartCoroutine(SpeedBoost(speedBoostAmount, speedBoostTime));
    }
}
