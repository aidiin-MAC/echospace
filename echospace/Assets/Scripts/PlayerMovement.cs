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

    InputAction moveAction;
    InputAction lookAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("Look");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerActive)
        {
            Move();
            Look();
        }

    }

    private void Move()
    {
        myRigidbody.MovePosition(transform.position + (transform.right * moveAction.ReadValue<Vector2>().x * moveSpeed) + (transform.forward * moveAction.ReadValue<Vector2>().y * moveSpeed));
    }

    private void Look()
    {
        myRigidbody.angularVelocity = new Vector3(0, lookAction.ReadValue<Vector2>().x * lookSens, 0);
    }
}
