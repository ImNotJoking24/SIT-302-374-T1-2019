using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileScriptableObject Base;

    public string Name { get; private set; }
    public string Description { get; private set; }
    public float Damage { get; private set; }
    public float TimeActive { get; private set; }
    public float Speed { get; private set; }
    public float RechargeTimer { get; private set; }
    public PrimitiveType Model { get; private set; } //change this when model is available

    private GameObject _PrimitiveShape;

    private void Start()
    {
        Base = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStat>().ProjectileAbility;
        ThirdPersonCamera camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ThirdPersonCamera>();
        if (camera == null)
        {
            Destroy(gameObject);
        }
        Name = Base.Name;
        Description = Base.Description;
        Damage = Base.Damage;
        TimeActive = Base.TimeActive;
        Speed = Base.Speed;
        RechargeTimer = Base.RechargeTimer;
        Model = Base.model; //remove this when model is available
        _PrimitiveShape = GameObject.CreatePrimitive(Model); //remove this when model is available
        transform.LookAt(camera.LookingAtPoint);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        _PrimitiveShape.transform.position = this.transform.position;
        _PrimitiveShape.transform.rotation = this.transform.rotation;
        TimeActive -= Time.deltaTime;
        if (TimeActive <= 0)
        {
            Destroy(_PrimitiveShape); //change this when model is available
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(_PrimitiveShape); //change this when model is available
            Destroy(gameObject);
        }
    }
}
