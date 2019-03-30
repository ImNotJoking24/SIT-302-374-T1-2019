using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Projectile")]
public class ProjectileScriptableObject : ScriptableObject
{
    public string Name;
    public string Description;
    public float Damage;
    public float TimeActive;
    public float Speed;
    public float RechargeTimer;
    public PrimitiveType model; //change this when model is available
}
