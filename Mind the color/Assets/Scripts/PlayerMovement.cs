using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float playerIdleMoveSpeed = 1f;
    [SerializeField] private Transform cameraTransform;
    private Vector2 anchorPoint;
    private Rigidbody rb;

    [SerializeField] private float playerMinZThreshold = 2f; // player does not go past this threshold


    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void LateUpdate()
    {
        KeepPlayerInView();
    }

    private Vector3 moveDirection = Vector3.zero; // Stores movement direction

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anchorPoint = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 inputDelta = (Vector2)Input.mousePosition - anchorPoint;

            moveDirection = new Vector3(inputDelta.x, 0, inputDelta.y).normalized;
        }
        else
        {
            PlayerIdleMovement();
        }
    }

    private void HandleMovement()
    {
        rb.velocity = moveDirection * moveSpeed;
    }

    private void PlayerIdleMovement()
    {  
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, playerIdleMoveSpeed);
    }

    private void KeepPlayerInView()
    {
        if (transform.position.z < cameraTransform.position.z + playerMinZThreshold)
        {
            transform.position = new Vector3
            (
                transform.position.x,
                transform.position.y,
                cameraTransform.position.z + playerMinZThreshold
            );
        }
    }

}
