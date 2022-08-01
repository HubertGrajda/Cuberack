using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayVFXOnDisabled : MonoBehaviour
{
    [SerializeField] private VisualEffect vfx;
    private void OnDisable()
    {
        if (!gameObject.scene.isLoaded) 
            return;
        VisualEffect tmpVfx = Instantiate(vfx, transform.position, Quaternion.identity);
        tmpVfx.Play();
        Destroy(tmpVfx.gameObject,3f);
    }
}
