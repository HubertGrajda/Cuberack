using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PowerUpType : MonoBehaviour
{
    AudioManager audioManager;
    [SerializeField] private PowerUp_ScriptableObject[] powerUpSO;
    private MeshRenderer mr;
    private VisualEffect vfx;
    private int randomIndex;
    void Start()
    {
        randomIndex = Random.Range(0, powerUpSO.Length);
        
        mr = GetComponent<MeshRenderer>();
        vfx = powerUpSO[randomIndex].vfx;
        mr.material = powerUpSO[randomIndex].material;
        
        audioManager = AudioManager.Instance;
    }
    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
            return;
        VisualEffect tmpVfx = Instantiate(vfx, transform.position, Quaternion.identity);
        tmpVfx.Play();
        Destroy(tmpVfx.gameObject, 3f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            audioManager.PlaySound("PowerUp");

            powerUpSO[randomIndex].effect.ApplyEffect(other.gameObject);
            Destroy(gameObject);
        }
    }
}
