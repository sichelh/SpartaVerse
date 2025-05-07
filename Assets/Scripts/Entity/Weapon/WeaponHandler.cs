using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponHandler : MonoBehaviour
{
    SpriteRenderer renderer;
    Animator animator;

    private static readonly int IsAttack = Animator.StringToHash("IsAttack");

    [Header("Attack Info")]
    [SerializeField] private float delay = 1f;
    public float Delay { get => delay; set => delay = value; }

    [SerializeField] private float weaponSize = 1f;
    public float WeaponSize { get => weaponSize; set => weaponSize = value; }

    [SerializeField] private float power = 1f;
    public float Power { get=> power; set => power = value; }
    [SerializeField] private float speed = 1f;
    public float Speed { get => speed; set => speed = value; }

    [SerializeField] private float attackRange = 10f;
    public float AttackRange { get => attackRange; set => attackRange = value; }

    public LayerMask target;

    public DungeonPlayerController Controller { get; private set; }

    
    protected virtual void Start()
    {
        renderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        Controller = GetComponentInParent<DungeonPlayerController>();

        animator.speed = 1.0f / delay;
    }

    void Update()
    {
        
    }
    
    public virtual void weaponAttack()
    {
        animator.SetTrigger(IsAttack);
    }

    public virtual void WeaponRotate(bool isLeft)
    {
        renderer.flipY = isLeft;
    }
}
