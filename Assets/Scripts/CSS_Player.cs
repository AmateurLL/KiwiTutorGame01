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
    bool goUp = false;

    // (is funny) Vector2 moveRight = new Vector2(1, 0);

    public void Init()
    {
        this.m_rig2D = this.GetComponent<Rigidbody2D>();
        this.runSpd = 20.0f;
        this.horiMove = 20.0f;
    }

    void Awake()
    {
        this.Init();
    }

    // Update is called once per frame
    void Update()
    {
        horiMove = Input.GetAxisRaw("Horizontal") * this.runSpd;
    }

    private void FixedUpdate()
    {
        this.Movement();
    }
    public void Movement()
    {
        Vector3 targetVelo = new Vector2((horiMove * Time.fixedDeltaTime) * 10f, this.m_rig2D.velocity.y);
        this.m_rig2D.velocity = targetVelo;
    }
}
