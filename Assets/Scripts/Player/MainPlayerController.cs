using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private SpriteRenderer renderer;

    private Rigidbody2D rigidbody;

    private Vector2 lookDirection = Vector2.zero;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleAction();
        Rotate(lookDirection);
    }

    void HandleAction()
    {
        // 이동 세팅
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical).normalized;
        
        // 움직임이 있을 때만 보는 방향 갱신
        if (movement != Vector2.zero)
        {
            lookDirection = movement;
        }
        
        rigidbody.velocity = movement * speed;
    }

    void Rotate(Vector2 direction)
    {
        // 회전 방향 Atan로 구하기
        float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        // 회전 방향이 90도보다 크면 왼쪽 방향!
        bool isLeft = Mathf.Abs(rotation) > 90f;

        renderer.flipX = isLeft;
    }
}
