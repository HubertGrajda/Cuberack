using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Spawn : MonoBehaviour
{
    [SerializeField] private float chance;
    [SerializeField] private GameObject powerUp;

    public void Lottery()
    {
        if(Random.value <= chance)
        {
            GameObject tmp= Instantiate(powerUp, transform);
            tmp.transform.parent = null;
            Debug.Log("PowerUP spawned");
        }
        
    }


}
