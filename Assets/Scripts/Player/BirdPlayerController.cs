using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float playerSpeed = 1.0f;
    [SerializeField] float flapForce = 6f;
    bool isDead = false;
    bool isFlap = false;

    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isFlap = true;
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        Vector3 velocity = rb.velocity;
        velocity.x = playerSpeed;

        if (isFlap)
        {
            velocity.y = flapForce;
            isFlap = false;
        }

        rb.velocity = velocity;
    }

}
