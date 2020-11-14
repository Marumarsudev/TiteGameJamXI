using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float movementSpeed = 1;

    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 movement = new Vector2((Input.GetKey(SETTINGS.moveLeft) ? -1 : 0) + (Input.GetKey(SETTINGS.moveRight) ? 1 : 0), (Input.GetKey(SETTINGS.moveDown) ? -1 : 0) + (Input.GetKey(SETTINGS.moveUp) ? 1 : 0)).normalized;

        body.velocity = movement * movementSpeed * Time.fixedDeltaTime;
    }
}
