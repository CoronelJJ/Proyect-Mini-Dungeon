using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float movementSpeed = 5.0f;
    [SerializeField] float stopTimer = 0.2f;
    bool stopMovement = false;
    private Rigidbody2D rb;
    public Vector2 movementVector;
    

    [SerializeField] Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movementVector = setMoveVector(horizontalInput, verticalInput);

        animator.SetFloat("movementX", movementVector.x);
        animator.SetFloat("movementY", movementVector.y);

        if (Input.GetKey(KeyCode.Space))
        {
            stopMovement = true;
        }

        

        rb.linearVelocity = movementVector * movementSpeed;

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
