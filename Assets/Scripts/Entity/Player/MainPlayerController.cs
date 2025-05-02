using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainPlayerController : MonoBehaviour
{
    KeyBoardInputHandler inputHandler;
    MainUIManager mainUIManager;

    [SerializeField] private float speed = 5f;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private float jumpPower = 1.5f;
    [SerializeField] private float jumpDuration = 0.4f;

    private Rigidbody2D rigidbody;

    private Vector2 lookDirection = Vector2.zero;

    private bool isJump = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        inputHandler = GetComponent<KeyBoardInputHandler>();
        mainUIManager = FindObjectOfType<MainUIManager>();
    }

    void Update()
    {
        HandleAction();
        HandleInteraction();
        Rotate(lookDirection);
        HandleJump();
    }

    void HandleInteraction()
    {
        if (inputHandler.IsActionPressed() && mainUIManager.isFlappyBirdUIActive)
        {
            mainUIManager.LoadFlappyBirdGame();
        }
        if (inputHandler.IsActionPressed() && mainUIManager.isDungeonUIActive)
        {
            mainUIManager.LoadDungeomGame();
        }
    }

    void HandleJump()
    {
        if(inputHandler.IsActionPressed() && !mainUIManager.isFlappyBirdUIActive && !mainUIManager.isDungeonUIActive)
        {
            if (!isJump)
            {
                StartCoroutine(JumpRoutine());
            }
        }
        
    }

    private IEnumerator JumpRoutine()
    {
        isJump = true;

        float elapsed = 0f;

        Vector3 startPos = renderer.transform.localPosition;
        Vector3 targetPos = startPos + new Vector3(0, jumpPower, 0);

        while (elapsed <jumpDuration / 2f)
        {
            renderer.transform.localPosition = Vector3.Lerp(startPos, targetPos, elapsed / (jumpDuration / 2f));
            elapsed += Time.deltaTime;
            yield return null;
        }

        renderer.transform.localPosition = targetPos;
        elapsed = 0f;

        while (elapsed < jumpDuration / 2f)
        {
            renderer.transform.localPosition = Vector3.Lerp(targetPos, startPos, elapsed / (jumpDuration / 2f));
            elapsed += Time.deltaTime;
            yield return null;
        }

        renderer.transform.localPosition = startPos;
        isJump = false;

    }


    void HandleAction()
    {
        Vector2 movement = inputHandler.GetMoveMentInput();

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
