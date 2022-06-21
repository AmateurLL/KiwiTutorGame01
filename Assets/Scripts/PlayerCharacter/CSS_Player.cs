using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DON'T CREATE WHITE SPACES
public class CSS_Player : MonoBehaviour
{
    //Lists Componenents of the Player in the editor
    [Header("Components")]
    [SerializeField] private Rigidbody2D m_rig2D;
    [SerializeField] private Transform m_GroundCheckCol;

    //List of variables and controls (of the Player)
    [Space]
    [Header("Stats")]
    public float runSpd;
    float horiMove;
    float jumpPower;
    private bool isJumping = false;
    private bool isFacingRight = true;
    private bool isGrounded;
    public float spdMod;
    public float isTimeUp;
    private float TBearTrapTimer;
    Vector2 movement;
    // (is funny) Vector2 moveRight = new Vector2(1, 0);

    // Initializes the player's variables, controls, and components when the scene is loaded.
    public void Init()
    {
        this.m_rig2D = this.GetComponent<Rigidbody2D>();
        this.m_GroundCheckCol = this.transform.GetChild(1);
        this.movement = new Vector2(0, 0);
        this.runSpd = 7.0f;
        this.horiMove = 20.0f;
        this.jumpPower = 12.5f;
        this.spdMod = 1.0f;
        this.TBearTrapTimer = 3.0f;
    }
    // Runs when the player is initialized
    void Awake()
    {
        this.Init();
    }

    // Update is called once per frame
    void Update()
    {
        // Assigns horiMove (float) to the value given by moving on the horizontal axis
        // (-1 --> 1 and vice versa), multiplied by the variable runSpd (float).
        horiMove = Input.GetAxisRaw("Horizontal") * this.runSpd;

        // If the space key is pressed, and the circle collider from the child object PlayerGroundCheck by accessing the script.
        // Is touching an object with the tag "Grounded", you are able to jump.
        if (Input.GetKeyDown("space") && m_GroundCheckCol.GetComponent<CSS_PlayerGroundCheck>().GetisGrounded())
        {
            this.isJumping = true;
        }
    }
    // Runs Movement() repeatedly after a fixed period of time.
    private void FixedUpdate()
    {
        this.Movement();
    }
    // This function controlls the player movement.
    public void Movement()
    {
        // Movement is a vector 2. These hold a x (horizontal) and y (vertical) value.
        // The horizontal position is equal to the horizontal movement, and the vertical position is equal to the velocity on the y axis.
        this.movement.x = horiMove;
        this.movement.y = this.m_rig2D.velocity.y;
        //Old idea for movement - Vector3 targetVelo = new Vector2((horiMove * Time.fixedDeltaTime) * 10f, this.m_rig2D.velocity.y);
        //If jumping is true, the if statment has been fufilled
        if (this.isJumping)
        {
            // This code makes the player jump equal to the jumpPover (float).
            // It then makes it so the player can not jump again until they touch the ground.
            this.movement.y = this.jumpPower;
            this.isJumping = false;
            m_GroundCheckCol.GetComponent<CSS_PlayerGroundCheck>().SetisGrounded(false);
        }
        // This sets the player's rigidbody velocity to the player's calculated movement (float).
        this.m_rig2D.velocity = this.movement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TBearTrap")
        {
            spdMod = 0.25f;
            TBearTrapTimer -= Time.deltaTime;
            if (TBearTrapTimer <= 0.0f)
            {
                spdMod = 1.0f;
                TBearTrapTimer = 3.0f;
            }
        }
    }
}
