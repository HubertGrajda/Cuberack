using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime* speed);
    }
}
