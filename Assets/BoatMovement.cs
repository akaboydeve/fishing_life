using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    [SerializeField] private float _speed=5f; // The speed at which the player moves
    Rigidbody rb; // The player's rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the rigidbody component

    }

    void Update()
    {
       CalculateMovement();
    }

    void CalculateMovement()
    {
        // Get the horizontal and vertical input
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Calculate the movement direction
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        // Normalize the movement direction if it's greater than 1
        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }

        // Set the player's velocity based on the movement direction
        rb.velocity = movement * _speed;
    }
}
