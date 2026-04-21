using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    //player movement attributes
    public float moveSpeed;
    public float lookSens;

    //track current gamestate
    public bool playerActive;
    public bool replayActive;
    public bool replayRecord;
   
    //external references
    public Rigidbody myRigidbody;

    //player input references
    InputAction moveAction;
    InputAction lookAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //initialize input readings
        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("Look");
<<<<<<< Updated upstream
=======

        //initialize game state management
        Manager = GameObject.FindGameObjectWithTag("Manager");
        Story = Manager.GetComponent<StoryManager>();
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        if (playerActive)
        {
            Move();
            Look();
=======
        //Checks if player is allowed to move in the current game state
        playerActive = Story.canMove;

        //If the current game state is the start/reset phase, reset player position and begin the game if movement input is detected
        if (Story.chapter == 0)
        {
            transform.position = new Vector3(-172.28f, 0.48f, -38.26f);
            if (moveAction.ReadValue<Vector2>().x != 0 | moveAction.ReadValue<Vector2>().y != 0)
            {
                Debug.Log("Begin the experience");
                Story.IncrementChapter();
            }
>>>>>>> Stashed changes
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
        }
    }

    private void Move()
    {
<<<<<<< Updated upstream
        myRigidbody.MovePosition(transform.position + (transform.right * moveAction.ReadValue<Vector2>().x * moveSpeed) + (transform.forward * moveAction.ReadValue<Vector2>().y * moveSpeed));
=======
        //updates rigidbody position with vectors from player input
        myRigidbody.MovePosition(myRigidbody.position + new Vector3(moveAction.ReadValue<Vector2>().x, 0, moveAction.ReadValue<Vector2>().y) * moveSpeed);
>>>>>>> Stashed changes
    }

    private void Look()
    {
        //updates rigidbody angular velocity with player input
        myRigidbody.angularVelocity = new Vector3(0, lookAction.ReadValue<Vector2>().x * lookSens, 0);
    }
}
