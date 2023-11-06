using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Inputs
{
    
    public static PlayerActions _controls;

    private static Player _owner;

    public static void BindNewPlayer(Player myPlayer){
        _owner = myPlayer;
    }

    public static void Init(Player myPlayer)
    {
        // Variable
        _controls = new PlayerActions();
        BindNewPlayer(myPlayer);

        // Helps activate the code to make the set key work properly
        _controls.Game.Movement.performed += ctx => 
        {
            _owner.SetMovementDirection(ctx.ReadValue<Vector3>());
        };
        _controls.Game.Jump.performed += ctx => {_owner.Jump();};

        // Makes the previous line of code work forever until game shutdown
        _controls.Permanent.Enable();
    }

    // Will close the UI Hub if open and reveals the game screen
    public static void GameMode()
    {
        _controls.Game.Enable();
        _controls.UI.Disable();
    }
    
    // Closes the Game screen if open and starts up the UI Hub
    public static void UIMode()
    {
        _controls.Game.Disable();
        _controls.UI.Enable();
    }
    
    
    
    /*
    PlayerAction inputAction;
    Vector2 move;
    Vector2 rotate;

    Rigidbody rb;



    private flort distanceToGround;
    Bool isGrounded;
    public float jump = 5f;
    public float walkSpeed = 5f;

    private Animator playerAnimator;


    // Start is called before the first frame update
    private static PlayerAction _actions;
    private static PlayerController _owner;
    public static void BindNewPlayer(PlayerController player){
        _owner = player;
        
    }
    private void Awake() {
        rb = GetComponent<Rigidbody>();
        Inputs.Init(this);
    }
    */
    /* 20 frames per second
    1/20 = 0.05
    20 * 1 * 10 * 0.05 = 10
    1/500 = 0.002
    500 * 1 * 10 * 0.002 = 10 */
    /*private void Update()
    {
       transform.Translate(Vector1.forward + (move.y + Time.deltaTime + walkSpeed), Space.Self);
       transform.Translate(Vector1.right + (move.x + Time.deltaTime + walkSpeed), Space.Self); 
       isGrounded = Physics.Raycast(transform.position, -Vector3.up,GetComponent<Collider>().bounds.);
    }

    public void Jump()
    {
        if(isGrounded){
            rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
        }
    }
    public void Move(Vector2 direction)
    {
        move = direction;
    }*/
}
