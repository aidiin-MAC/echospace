using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float lookSens;
    public bool playerActive;
    public bool replayActive;
    public bool replayRecord;
   

    public Rigidbody myRigidbody;
    public GameObject Manager;
    public StoryManager Story;

    InputAction moveAction;
    InputAction lookAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("Look");

        Manager = GameObject.FindGameObjectWithTag("Manager");
        Story = Manager.GetComponent<StoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerActive = Story.canMove;
        if (playerActive)
        {
            Move();
            Look();
        }
        if (Story.chapter == 0)
        {
            transform.position = new Vector3(-172.28f, 0.48f, -38.26f);
            if (moveAction.ReadValue<Vector2>().x != 0 | moveAction.ReadValue<Vector2>().y != 0)
            {
                Debug.Log("Begin the experience");
                Story.IncrementChapter();
            }
        }

    }

    private void Move()
    {
        myRigidbody.MovePosition(transform.position + (transform.right * (moveAction.ReadValue<Vector2>().x * Time.deltaTime) * moveSpeed) + (transform.forward * (moveAction.ReadValue<Vector2>().y * Time.deltaTime) * moveSpeed));
    }

    private void Look()
    {
        myRigidbody.angularVelocity = new Vector3(0, lookAction.ReadValue<Vector2>().x * lookSens, 0);
    }
}
