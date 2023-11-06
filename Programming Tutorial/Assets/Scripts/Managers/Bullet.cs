using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private float curSpeed;
    private float curDamage;
    public float baseSpeed;
    private Vector3 curDirection;
    public float contactDamage;
    private Rigidbody Owner;
    public float lifespan = 0;
    public void Initalize(float chargePercent, Rigidbody owner)
    {
        this.Owner = owner;
        curDirection = transform.right;
        curSpeed = baseSpeed * chargePercent;
        curDamage = contactDamage + chargePercent;
        
        GetComponent<Rigidbody>().AddForce(transform.forward*curSpeed,ForceMode.Impulse);

    }
}
