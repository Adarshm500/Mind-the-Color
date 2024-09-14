using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float playerIdleMoveSpeed = 4f;
    [SerializeField] private Transform cameraTransform;
    private Vector2 anchorPoint;
    private Rigidbody rb;


    [SerializeField] private float playerMinZThreshold = 2f; // player does not go past this threshold


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleMovement();
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    private void LateUpdate()
    {
        KeepPlayerInView();
    }

    private Vector3 moveDirection = Vector3.forward; // Stores movement direction

    private void HandleMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anchorPoint = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector2 inputDelta = (Vector2)Input.mousePosition - anchorPoint;

            moveDirection = new Vector3(inputDelta.x, rb.velocity.y, inputDelta.y).normalized;
            rb.velocity = moveDirection * moveSpeed;
        }
        else
        {
            PlayerIdleMovement();
        }
    }

    private void PlayerIdleMovement()
    {  
        rb.velocity = new Vector3(moveDirection.x * playerIdleMoveSpeed, rb.velocity.y, moveDirection.z * playerIdleMoveSpeed);
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
