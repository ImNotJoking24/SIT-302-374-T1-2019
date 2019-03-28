using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Projectile Projectile;
    public ProjectileScriptableObject Type;

    private bool _CanShoot = true;
    private float _CanShootTimer = 0;

    private void Update()
    {
        _CanShootTimer += Time.deltaTime;
        if (_CanShootTimer >= Type.RechargeTimer)
        {
            _CanShoot = true;
        }
    }

    private void LateUpdate()
    {
        float fire = Input.GetAxisRaw("Fire1");
        if (fire == 1 && Projectile != null && _CanShoot == true)
        {
            _CanShoot = false;
            _CanShootTimer = 0;
            Instantiate(Projectile, transform.position + new Vector3(0f, 0f, 1f), transform.rotation);
        }
    }
}
