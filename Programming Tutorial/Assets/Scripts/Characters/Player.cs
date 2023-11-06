using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    PlayerActions inputAction;
    Vector2 move;
    Vector2 rotate;

    Rigidbody rb;



    private float distanceToGround;
    bool isGrounded;
    public float jump = 5f;
    public float walkSpeed = 5f;

    private Animator playerAnimator;

    [SerializeField] private Weapon weapon;
    private bool isAttacking;
    [SerializeField] private float speed;
    private Vector3 _moveDir;

    // Links back to the Input Manager script on startup
    private void Awake()
    {
        Inputs.Init(this);
        rb = GetComponent<Rigidbody>();
        Inputs.GameMode();
    }
    /*private void Awake() {
        rb = GetComponent<Rigidbody>();
        Inputs.Init(this);
    }*/
    // Will allow for the change of movement speed
    private void Update()
    {
        transform.position +=(_moveDir * speed * Time.deltaTime);
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y);
    }
    
    // Allows the change of the direction that the object is moving in
    public void SetMovementDirection(Vector3 newDirection)
    {
        _moveDir = newDirection;
    }

    public void Jump()
    {
        if(isGrounded){
            rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.x);
        }
    }

    public void Move(Vector2 direction)
    {
        move = direction;
    }

    public void shoot(){
        isAttacking = !isAttacking;
        if(isAttacking) weapon.StartAttack();
        else weapon.EndAttack();
        // Rigidbody rbBullet = Instantiate(projectile,projectPos.position,Quaternion.Identity).GetComponent<RigidBody>();
        // rbBullet.AddForce(Vector3.forward*32f,ForceMode.Impulse);
    }

    public void Die()
    {
        
    }

    public void TakeDamage(float damageTaken)
    {

    }

    /*
    // Camera
    public void SetLook(Vector2 direction)
    {
        rotate = direction;
        // Considered the advanced rotation and prevents global look
        transform.rotation *= Quaternion.AngleAxis(direction.x * sensitivity, Vector3.up); // Horizontal
        camFollowTarget.rotation *= Quaternion.AngleAxis(direction.y * -sensitivity, Vector4.right) // Vertical

        Vector3 angles = camFollowTarget.eulerAngles;
        float anglesX = angles.x;
        if (anglesX > 180 && anglesX < 360-viewAngleClamp)
        {
            anglesX = 360-viewAngleClamp;
        }
        else if (anglesX < 180 && anglesX > viewAngleClamp)
        {
            anglesX = viewAngleClamp;
        }
        // transform.rotation - Quaternion.Euler(o, angles.y, 0);
        camFollowTarget.localEulerAngles = new Vector3(anglesX, 0, 0);
    }*/
}
