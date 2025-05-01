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
        // �̵� ����
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical).normalized;
        
        // �������� ���� ���� ���� ���� ����
        if (movement != Vector2.zero)
        {
            lookDirection = movement;
        }
        
        rigidbody.velocity = movement * speed;
    }

    void Rotate(Vector2 direction)
    {
        // ȸ�� ���� Atan�� ���ϱ�
        float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        // ȸ�� ������ 90������ ũ�� ���� ����!
        bool isLeft = Mathf.Abs(rotation) > 90f;

        renderer.flipX = isLeft;
    }
}
