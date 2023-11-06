using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private float TrueDamage;

    private void OnCollisionEnter(Collision other)
    {
        print(other.transform.name + "," + other.transform.root.name);

        if(other.transform.root.TryGetComponent(out IDamagable hitTarget)){
            hitTarget.TakeDamage(TrueDamage);
        }
    }

}
