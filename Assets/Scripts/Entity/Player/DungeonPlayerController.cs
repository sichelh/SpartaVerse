using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonPlayerController : MonoBehaviour
{
    Animator animator;
    MouseInputHandler mouseInputHandler;
    KeyBoardInputHandler keyInputHandler;
    Rigidbody2D rb;

    Camera camera;

    Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    [SerializeField] float speed = 5f;
    [SerializeField] SpriteRenderer renderer;

    [Header("Weapon")]
    [SerializeField] Transform weaponPivot;
    [SerializeField] WeaponHandler WeaponPrefab;
    WeaponHandler weaponHandler;

    bool isAttacking;
    float timeSinceLastAttack = float.MaxValue;
    
    public void Init()
    {
        
    }

    void Awake()
    {
        camera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        mouseInputHandler = GetComponent<MouseInputHandler>();
        keyInputHandler = GetComponent<KeyBoardInputHandler>();
        animator = GetComponentInChildren<Animator>();
        

        if (WeaponPrefab != null)
            weaponHandler = Instantiate(WeaponPrefab, weaponPivot);
        else
            weaponHandler = GetComponentInChildren<WeaponHandler>();
    }

    void Update()
    {
        HandleAction();
        Rotate(lookDirection);
        HandleAttackDelay();
    }

    void HandleAction()
    {
        Vector2 movement = keyInputHandler.GetMoveMentInput();

        animator.SetBool("isMove", movement.magnitude > 0.5f);

        rb.velocity = movement * speed;

        Vector2 mousePos = Input.mousePosition;
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePos);
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < .9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }

        isAttacking = Input.GetMouseButton(0);

    }

    void HandleAttackDelay()
    {
        if (weaponHandler == null)
            return;

        if(timeSinceLastAttack <= weaponHandler.Delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }

        if(isAttacking && timeSinceLastAttack > weaponHandler.Delay)
        {
            timeSinceLastAttack = 0;
            Attack();
        }
    }

    void Attack()
    {
        if(lookDirection != Vector2.zero)
        {
            weaponHandler?.weaponAttack();
        }
    }

    void Rotate(Vector2 direction)
    {
        float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotation) > 90f;

        renderer.flipX = isLeft;

        if (weaponPivot != null)
        {
            weaponPivot.rotation = Quaternion.Euler(0, 0, rotation);
        }

        weaponHandler?.WeaponRotate(isLeft);
    }
}
