using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : Weapon
{
    

    [SerializeField] private Transform firepoint;
    [SerializeField] private Bullet bul;

    protected override void Attack(float chargePercent)
    {
        Bullet current = Instantiate(bul,firepoint.position,owner.transform.rotation);

    }
}
