using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMovement : MonoBehaviour
{
    private float movementSpeed;
    public float rotationSpeed = 200.0f;

    private void Start()
    {
        movementSpeed = 0;
    }

    void Update()
    {
        // Not at max positive speed with forward input
        if (movementSpeed < 10 && Input.GetAxis("Vertical") > 0)
        {
            movementSpeed += 0.01f;
        }
        else if (movementSpeed > -10 && Input.GetAxis("Vertical") < 0) // Not at max negative speed with backward input 
        {
            movementSpeed -= 0.01f;
        }
        else if (Math.Abs(movementSpeed) > 0 && Math.Abs(Input.GetAxis("Vertical")) == 0) // Moving with no input
        {
            movementSpeed = movementSpeed > 0 ? movementSpeed - 0.01f : movementSpeed + 0.01f;
        }
        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, Time.deltaTime * movementSpeed);
    }
}
