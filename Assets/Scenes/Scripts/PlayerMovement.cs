using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float movementSpeed = 5.0f;
    [SerializeField] float maxSpeed = 5.0f;
    [SerializeField] float attackDuration = 0.2f;
    [SerializeField] float attackTimer;
    bool stopMovement = false;
    Rigidbody2D rb;
    Vector2 movementVector;
    public Vector2 lastDirection;
    

    [SerializeField] Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    Vector2 inputVector = setMoveVector(horizontalInput, verticalInput);


        if (!stopMovement)
        {
            movementVector = inputVector;

            if (inputVector.x != 0 || inputVector.y != 0)
            {

                lastDirection = inputVector;
            }
            else if (inputVector == Vector2.zero)
            {
                lastDirection = inputVector;
            }
    }

        
    animator.SetFloat("movementX", lastDirection.x);
    animator.SetFloat("movementY", lastDirection.y);

    
    if (Input.GetKeyDown(KeyCode.Space) && !stopMovement)
    {
        stopMovement = true;
        attackTimer = attackDuration;
    }

    
    if (stopMovement)
    {
        rb.linearVelocity = Vector2.zero;
        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0f)
            stopMovement = false;
    }
    else
    {
        rb.linearVelocity = movementVector * movementSpeed;
    }

    }


    Vector2 setMoveVector(float horizontalInput, float verticalInput)
    {
        Vector2 movVector = new Vector2();

        if (horizontalInput != 0)
        {
            movVector.x = horizontalInput;
            movVector.y = 0;
            movVector.Normalize();

        }
        else if (verticalInput != 0)
        {
            movVector.x = 0;
            movVector.y = verticalInput;
            movVector.Normalize();

        }

        return movVector;
    }
}
