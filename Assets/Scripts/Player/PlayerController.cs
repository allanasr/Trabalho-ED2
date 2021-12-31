using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float jumpImpulse = 500f;
    private Rigidbody2D rigidbody;
    private bool jumping = false;

    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
    private bool facingRight = true;
    private float horizontalMove = 0f;
    private Vector3 m_Velocity = Vector3.zero;

    const float k_GroundedRadius = .2f;
    [SerializeField] private LayerMask m_WhatIsGround;
    private bool grounded;
    [SerializeField] private Transform m_GroundCheck;

    [Header("Events")] [Space] public UnityEvent OnLandEvent;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    private void FixedUpdate()
    {
        bool wasGrounded = grounded;
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }

    public void Move(float move, bool jump)
    {
        Vector3 targetVelocity = new Vector2(move * 10f, rigidbody.velocity.y);
        rigidbody.velocity = Vector3.SmoothDamp(rigidbody.velocity, targetVelocity, ref m_Velocity, movementSmoothing);
        if (jump && grounded)
        {
            rigidbody.AddForce(new Vector2(0f, jumpImpulse));
        }

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}