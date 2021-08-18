using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerMove : BaseSingletonWithMono<PlayerMove>
{
    private Rigidbody2D rigid2d;
    private BoxCollider2D collider2d;
    private Animator animator;
    private Collider2D attachFloor;
    [SerializeField] private float WalkSpeed = 5.0f;
    [SerializeField] private float RunSpeed = 10.0f;
    [SerializeField] private float JumpHeight = 8.0f;
    [SerializeField] private float AirSpeedMuti = 0.8f;
    [SerializeField] private float GravityScale = 2.0f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;


    private bool isGround = false;
    private bool isKeepSpeed = false;
    private bool isAllowJump = false;
    private bool isAllowDown = false;
    private float moveDir = 0;
    private float improveSpeed = 0;
    public bool OnJump => isAllowJump;
    // Start is called before the first frame update
    private void Awake()
    {
   
    }
    private void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<BoxCollider2D>();
        animator = GetComponentInChildren<Animator>();
        rigid2d.gravityScale = GravityScale;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space) && isGround)
            isAllowDown = true;
        if (Input.GetButtonDown("Jump") && isGround)
            isAllowJump = true;
    }
    private void FixedUpdate()
    {
        attachFloor = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
        isGround = attachFloor ? true : false;
        animator.SetBool("HitGround", isGround);
        Move();
        Down();
        Jump();
    }
    public void AddImproveSpeed(float _speed)
    {
        improveSpeed += _speed;
    }
    private void Move()
    {
        float runOrwalk = (Input.GetKey(KeyCode.LeftShift) ? RunSpeed : WalkSpeed) + improveSpeed;
        float currentSpeed = isGround ? runOrwalk : runOrwalk * AirSpeedMuti;
        //移动的方向
        moveDir = Input.GetAxisRaw("Horizontal");
        //若角色在空中，则令其保持速度
        if (!isGround && isKeepSpeed && moveDir == 0.0f)
            moveDir = transform.localScale.x * 1.0f;
        //移动角色
        rigid2d.velocity = new Vector2(moveDir * currentSpeed, rigid2d.velocity.y);
        //设置状态机
        animator.SetFloat("VelocityX", Mathf.Abs(rigid2d.velocity.x) / (RunSpeed * ((AirSpeedMuti > 1.0f) ? AirSpeedMuti : 1.0f)));
        animator.SetFloat("VelocityY", rigid2d.velocity.y);
        if (moveDir != 0)
            transform.localScale = new Vector3(moveDir, 1, 1);
    }
    private void Jump()
    {
        if (isAllowJump)
        {
            rigid2d.velocity = new Vector2(rigid2d.velocity.x, JumpHeight);
            isAllowJump = false;
            if (Mathf.Abs(moveDir) > 0.1f)
                isKeepSpeed = true;
            else
                isKeepSpeed = false;
        }
    }
    private void Down()
    {
        if (isAllowDown)
        {
            isAllowJump = false;
            var pe2d = attachFloor?.gameObject.GetComponent<PlatformEffector2D>();
            LayerMask mask = 0 << LayerMask.NameToLayer("Ground");
            if (pe2d)
            {
                pe2d.colliderMask = mask;
                StartCoroutine(ReopenLayer(pe2d));
            }
            isAllowDown = false;
            //碰到新地板的时候将Layer改回来
        }
    }
    IEnumerator ReopenLayer(PlatformEffector2D pe2d)
    {
        while (attachFloor != null)
        {
            yield return null;
        }
        yield return new WaitForSeconds(0.2f);
        pe2d.colliderMask = ~(1 << 0);
    }
}
