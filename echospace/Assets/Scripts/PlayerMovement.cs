using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    //player movement attributes
    public float moveSpeed;
    public float lookSens;

    //used to orient camera when in single stick mode
    private Vector3 moveDirection;
    public bool freeCam;
//    InputAction cameraToggleAction;

    //track current gamestate
    public bool playerActive;
//    public bool replayActive;
//    public bool replayRecord;

   
    //external references
    public Rigidbody myRigidbody;

    //player input references
    InputAction moveAction;
    InputAction lookAction;

    //story manager references
    GameObject Manager;
    StoryManager Story;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //initialize input readings
        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("Look");
//        cameraToggleAction = InputSystem.actions.FindAction("Attack");

        //initialize game state management
        Manager = GameObject.FindGameObjectWithTag("Manager");
        Story = Manager.GetComponent<StoryManager>();

        freeCam = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if player is allowed to move in the current game state
        playerActive = Story.canMove;

        //If the current game state is the start/reset phase, reset player position and begin the game if movement input is detected
        if (Story.chapter == 0)
        {
            transform.position = new Vector3(-172.28f, 0.48f, -38.26f);
            transform.LookAt(new Vector3(0, 0, 1) + transform.position);
            if (moveAction.ReadValue<Vector2>().x != 0 | moveAction.ReadValue<Vector2>().y != 0)
            {
                Debug.Log("Begin the experience");
                Story.IncrementChapter();
            }
        }

    }

    //FixedUpdate is called once per physics update
    private void FixedUpdate()
    {
        //Run funcions for player movement and look angle updates if player is allowed to move
        if (playerActive)
        {
            Move();
            Look();
/*            if (cameraToggleAction.IsPressed())
            {
                freeCam = !freeCam;
            }*/
        }
    }

    private void Move()
    {
        if (freeCam==true)
        {
            transform.Translate(moveAction.ReadValue<Vector2>().x * moveSpeed, 0, moveAction.ReadValue<Vector2>().y * moveSpeed);
            
        }
        else {
            transform.position = (myRigidbody.position + new Vector3(moveAction.ReadValue<Vector2>().x, 0, moveAction.ReadValue<Vector2>().y) * moveSpeed);
        }
    }

    private void Look()
    {
        if (freeCam==true)
        {
            //updates rigidbody angular velocity with player input
            myRigidbody.angularVelocity = new Vector3(0, lookAction.ReadValue<Vector2>().x * lookSens, 0);
        }
        else
        {
            moveDirection = new Vector3(moveAction.ReadValue<Vector2>().x, 0, moveAction.ReadValue<Vector2>().y).normalized;
            transform.LookAt(moveDirection + transform.position);
        }
    }
}
