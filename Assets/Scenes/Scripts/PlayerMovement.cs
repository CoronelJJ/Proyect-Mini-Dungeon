using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed = 10.0f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movVector = new Vector2(horizontalInput, verticalInput);
        movVector.Normalize();

        rb.linearVelocity = movVector * movementSpeed;

    }
}
