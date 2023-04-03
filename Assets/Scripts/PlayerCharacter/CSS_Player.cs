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
    [SerializeField] private CSS_EFFKnockback m_KBInstance;
    [SerializeField] private CSS_EFFSpeedBoost m_SpeedInstance;
    private Transform playerObjTrans;

    //List of variables and controls (of the Player)
    [Space]
    [Header("Stats")]
    public float runSpd;
    float horiMove;
    float jumpPower;
    public float jumpMod;
    [SerializeField] private bool isJumping = false;
    private bool isFacingRight = true;
    private bool isGrounded = false;
    public float spdMod;
    public int hp;
    private float modifyTime;
    public bool knockBackTrue = false;
    public float maxVelocityX;
    public float maxVelocityY;
    public float maxVelocityMod;
    [SerializeField] private bool isAffected = false; //Controls modification time
    Vector2 movement;
    // (is funny) Vector2 moveRight = new Vector2(1, 0);

    // Initializes the player's variables, controls, and components when the scene is loaded.
    public void Init()
    {
        this.m_rig2D = this.GetComponent<Rigidbody2D>();
        this.m_GroundCheckCol = this.transform.GetChild(1);
        this.m_KBInstance = this.GetComponent<CSS_EFFKnockback>();
        this.m_SpeedInstance = this.GetComponent<CSS_EFFSpeedBoost>();
        this.movement = new Vector2(0, 0);
        this.runSpd = 8.0f; // Acts as acceleration
        this.horiMove = 0.0f; // Acts as velocity
        this.jumpPower = 12.5f;
        this.jumpMod = 1.0f;
        this.spdMod = 1.0f;
        this.hp = 100;
        this.playerObjTrans = this.transform;
        this.maxVelocityX = 10.0f;
        this.maxVelocityY = 30.0f;
        this.maxVelocityMod = 1.0f;
    }

    // Runs when the player is initialized
    void Awake()
    {
        this.Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (!CSS_GameManager.Instance.GetIsGameOver())
        {
            // Assigns horiMove (float) to the value given by moving on the horizontal axis
            // (-1 --> 1 and vice versa), multiplied by the variable runSpd (float).

            //doesn't utilize midair momentum (everything but horiMove equation)
            //if (Input.GetAxisRaw("Horizontal") != 0)
            //{
            //    horiMove = Input.GetAxisRaw("Horizontal") * this.runSpd * this.spdMod;
            //}
            //else
            //{
            //    horiMove = 0;
            //}
            horiMove = Input.GetAxisRaw("Horizontal") * this.runSpd * this.spdMod;
            PlayerFacing();
            // If the space key is pressed, and the circle collider from the child object PlayerGroundCheck by accessing the script.
            // Is touching an object with the tag "Grounded", you are able to jump.
            if (Input.GetKeyDown("space") && m_GroundCheckCol.GetComponent<CSS_PlayerGroundCheck>().GetisGrounded())
            {
                this.isJumping = true;
            }
        }
        ModCountdown();
        DeathCheck();
    }


    // Runs Movement() repeatedly after a fixed period of time.
    private void FixedUpdate()
    {
        if (!CSS_GameManager.Instance.GetIsGameOver())
        {
            this.Movement();
        }
    }

    public void PlayerFacing()
    {
        float x = this.transform.localScale.x;
        float y = this.transform.localScale.y;
        float z = this.transform.localScale.z;
        if (Input.GetAxisRaw("Horizontal") == 1 && !isFacingRight)
        {
            isFacingRight = true;
            if (this.transform.localScale.x <= -1)
            {
                x *= -1;
            }
            this.transform.localScale = new Vector3(x, y, z);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1 && isFacingRight)
        {
            isFacingRight = false;
            x *= -1;
            this.transform.localScale = new Vector3(x, y, z);
        }
    }
    // This function controlls the player movement.
    public void Movement()
    {
        // Movement is a vector 2. These hold a x (horizontal) and y (vertical) value.
        // The horizontal position is equal to the horizontal movement, and the vertical position is equal to the velocity on the y axis.
        //if (knockBackTrue)
        //{
        //    this.movement.x = this.m_rig2D.velocity.x + horiMove/70;
        //    this.movement.y = this.m_rig2D.velocity.y;
        //    if (!m_GroundCheckCol.GetComponent<CSS_PlayerGroundCheck>().GetisGrounded())
        //    {
        //        knockBackTrue = false;
        //    }
        //}

        //if (!m_GroundCheckCol.GetComponent<CSS_PlayerGroundCheck>().GetisGrounded())
        //{
        //    maxVelocityX = 5.0f;
        //}
        //else
        //{
        //    maxVelocityX = 10.0f;
        //}

        //This sets the velocity of the players vector to equal the rigidbody velocity +
        //the directional movement, and ensuring it is not greater than max velocity.
        this.movement.x = this.m_rig2D.velocity.x + horiMove;
        this.movement.x = ChangingVelocity(this.movement.x, maxVelocityX);
        this.movement.y = this.m_rig2D.velocity.y;
        this.movement.y = ChangingVelocity(this.movement.y, maxVelocityY);

        if (this.m_KBInstance.GetIsKnockBack())
        {
            knockBackTrue = true;
        }

        // doesn't utilize midair momentum
        //if (horiMove == 0)
        //{
        //    this.movement.x = 0;
        //}

        //Old idea for movement - Vector3 targetVelo = new Vector2((horiMove * Time.fixedDeltaTime) * 10f, this.m_rig2D.velocity.y);
        //If jumping is true, the if statment has been fufilled
        if (this.isJumping)
        {
            // This code makes the player jump equal to the jumpPover (float).
            // It then makes it so the player can not jump again until they touch the ground.
            //this.movement.y = (this.jumpPower * this.jumpMod) * this.spdMod;
            this.movement.y = m_rig2D.velocity.y;
            if (this.maxVelocityMod > 1)
            {
                this.movement.y += (this.jumpPower * this.jumpMod) * 1.25f;
            }
            else
            {
                this.movement.y += (this.jumpPower * this.jumpMod) * (this.maxVelocityMod);
            }
            this.movement.y = ChangingVelocity(this.movement.y, maxVelocityY);
            this.isJumping = false;
            m_GroundCheckCol.GetComponent<CSS_PlayerGroundCheck>().SetisGrounded(false);
            this.jumpMod = 1.0f;
        }

        // This sets the player's rigidbody velocity to the player's calculated movement (float).
        this.m_rig2D.velocity = this.movement;
    }

    public float ChangingVelocity(float movement, float maxVelo)
    {
        if (movement >= (maxVelo * maxVelocityMod))
        {
            movement = (maxVelo * maxVelocityMod);
        }
        else if (movement <= -(maxVelo * maxVelocityMod))
        {
            movement = -(maxVelo * maxVelocityMod);
        }
        return movement;
    }
    // Modifies the player's speed.
    private void ModCountdown()
    {
        //If the boolean is true (which can be changed from other scripts), then the timer will count down,
        //and upon raching 0 everything will be reset.
        if (isAffected)
        {
            modifyTime -= Time.deltaTime;
            if (modifyTime <= 0.0f)
            {
                maxVelocityMod = 1.0f;
                isAffected = false;
            }
        }
    }

    private void DeathCheck()
    {
        // Makes it so if the player reaches the goal, they can't die (avoids potenial bugs)
        if (!CSS_GameManager.Instance.GetIsGameOver() && hp <= 0)
        {
            //Debug.Log("u is die");
            CSS_GameManager.Instance.SetIsDead(true);
            //Object.Destroy(this);
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////
    //Getters and setters
    public void SetModTime(float _modTime)
    {
        modifyTime = _modTime;
    }

    public float GetModTime()
    {
        return this.modifyTime;
    }
    public void SetAffect(bool _isAffect)
    {
        isAffected = _isAffect;
    }

    public bool GetAffect()
    {
        return this.isAffected;
    }

    public void SetSpdMod(float _spdMod)
    {
        spdMod = _spdMod;
    }

    public float GetSpdMod()
    {
        return this.spdMod;
    }

    public void SetMaxVeloMod(float _maxMod)
    {
        maxVelocityMod = _maxMod;
    }

    public float GetMaxVeloMod()
    {
        return this.maxVelocityMod;
    }

    public void SetHP(int _health)
    {
        hp = _health;
    }

    public int GetHP()
    {
        return this.hp;
    }

    public void TakeDamage(int _health)
    {
        hp -= _health;
    }
    public Rigidbody2D GetRigid()
    {
        return this.m_rig2D;
    }

    public CSS_EFFKnockback GetIsKnockedBackInstance()
    {
        return this.m_KBInstance;
    }

    public CSS_EFFSpeedBoost GetIsSpeedBoostInstance()
    {
        return this.m_SpeedInstance;
    }

    public Transform GetPlayerObjTrans()
    {
        return this.playerObjTrans;
    }

    public void SetPlayerObjTrans(Vector3 _trans)
    {
        playerObjTrans.position = _trans;
    }

    public bool GetJump()
    {
        return this.isJumping;
    }

    public void SetJump(bool _jump)
    {
        isJumping = _jump;
    }

    public float GetJumpPower()
    {
        return this.jumpPower;
    }

    public void SetJumpPower(float _jumpPower)
    {
        jumpPower = _jumpPower;
    }

    public float GetJumpMod()
    {
        return this.jumpMod;
    }

    public void SetJumpMod(float _jumpMod)
    {
        jumpMod = _jumpMod;
    }
}
