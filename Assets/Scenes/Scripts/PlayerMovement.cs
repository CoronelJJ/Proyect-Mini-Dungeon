using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed = 5.0f;
    private Rigidbody2D rb;

    [SerializeField] Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movVector = setMoveVector(horizontalInput, verticalInput);

        animator.SetFloat("movementX", movVector.x);
        animator.SetFloat("movementY", movVector.y);

        Debug.Log(movVector);

        rb.linearVelocity = movVector * movementSpeed;

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
