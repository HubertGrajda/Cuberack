using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAfterDelay : MonoBehaviour
{
    private float lifetime;
    [SerializeField] private float timeToDeactivate;
    void OnEnable()
    {
        lifetime = 0;
    }
    private void Update()
    {
        lifetime += Time.deltaTime;
        {
            if(lifetime > timeToDeactivate)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
