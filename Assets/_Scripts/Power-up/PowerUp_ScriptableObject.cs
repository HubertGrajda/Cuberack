using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[CreateAssetMenu(fileName = "New PowerUp", menuName = "PowerUp")]
public class PowerUp_ScriptableObject : ScriptableObject
{
    public Material material;
    public PowerUpEffect effect;
    public VisualEffect vfx;
    
}