using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSS_Player : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D m_rig2D;

    [Space]
    [Header("Stats")]

    public float runSpd;
    float horiMove;
    float jumpPower;
    private bool isJumping = false;
    private bool isFacingRight = true;
    Vector2 movement;
    // (is funny) Vector2 moveRight = new Vector2(1, 0);

    public void Init()
    {
        this.m_rig2D = this.GetComponent<Rigidbody2D>();
        this.movement = new Vector2(0, 0);
        this.runSpd = 7.0f;
        this.horiMove = 20.0f;
        this.jumpPower = 12.5f;
    }

    void Awake()
    {
        this.Init();
    }

    // Update is called once per frame
    void Update()
    {
        horiMove = Input.GetAxisRaw("Horizontal") * this.runSpd;
        if (Input.GetKeyDown("space"))
        {
            this.isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        this.Movement();
    }
    public void Movement()
    {
        this.movement.x = horiMove;
        this.movement.y = this.m_rig2D.velocity.y;
        //Vector3 targetVelo = new Vector2((horiMove * Time.fixedDeltaTime) * 10f, this.m_rig2D.velocity.y);
        if (this.isJumping)
        {
            this.movement.y = this.jumpPower;
            this.isJumping = false;
        }
        this.m_rig2D.velocity = this.movement;
    }
}
