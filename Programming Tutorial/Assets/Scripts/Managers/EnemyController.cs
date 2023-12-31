using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public Transform player;
    public LayerMask groundlayer,playerlayer;

    
    Rigidbody enemy;
    public Vector3 walkpoint;
    bool walkpointset = false;

    public float walkPointRange;
    public bool playerInSightRange,playerInAttackRange;
    public float sightRange,attackRange;

    public GameObject projectile;
    public GameObject ProjectilePosition;
    public float timeBetweenAttacks;

    bool alreadyAttacked;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position,sightRange,playerlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position,attackRange,playerlayer);

        if(playerInSightRange && playerInAttackRange) Attack();

    }

    public void Attack()
    {

        transform.LookAt(player);

        if(alreadyAttacked)
        {
                if(alreadyAttacked){
                    Rigidbody rb = Instantiate(projectile,ProjectilePosition,transform.position,Quaternion.identity).GetComponent<Rigidbody>;
                    rb.AddForce(transform.forward*32f,ForceMode.Impulse);
                    rb.AddForce(transform.up*8f,ForceMode.Impulse);

                    alreadyAttacked = true;
                    Invoke(nameof(ResetAttack), timeBetweenAttacks);

                }
        }

    }

    public void ResetAttack()
    {
        alreadyAttacked = false;
    }

}