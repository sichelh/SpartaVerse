using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdPlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    KeyBoardInput keyInputHandler;
    MouseInput mouseInputHandler;

    [SerializeField] float playerSpeed = 1.0f;
    [SerializeField] float flapForce = 6f;
    bool isDead = false;
    bool isFlap = false;

    FlappyBirdUIManager uiManager;

    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        uiManager = FindObjectOfType<FlappyBirdUIManager>();
        keyInputHandler = GetComponent<KeyBoardInput>();
        mouseInputHandler = GetComponent<MouseInput>();
        isDead = false;
    }

    private void Update()
    {
        if (!GameManager.Instance.IsPlaying)
        {
            rb.simulated = false;
            return;
        }

        rb.simulated = true;

        if (isDead)
        {
            GameManager.Instance.EndGame();
            uiManager.OpenGameOverUI();
        }
        else
        {
            if (keyInputHandler.IsActionPressed() || mouseInputHandler.IsActionPressed())
            {
                isFlap = true;
            }
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

        float rotateY = Mathf.Clamp((rb.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, rotateY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        isDead = true;
        
    }

}
