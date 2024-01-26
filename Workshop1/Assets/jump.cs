using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    private Rigidbody rb;
    private float jumpDistance = 10;
    private float movementForce = 1f;
    private bool onGround;
    private float horizontalDirection;
    private float verticalDirection;
    private Vector3 movementDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision collision)
    {
        onGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        onGround = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump") && onGround)
        {
            rb.AddForce(Vector3.up * jumpDistance, ForceMode.Impulse);
        }

        horizontalDirection = Input.GetAxis("Horizontal");
        verticalDirection = Input.GetAxis("Vertical");
        movementDirection = new Vector3(horizontalDirection, 0, verticalDirection);
        rb.AddForce(movementDirection, ForceMode.Acceleration);

    }
}
