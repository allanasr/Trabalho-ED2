using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private bool facingRight = true;
    [SerializeField] public float jumpImpulse = 700f;
    private bool grounded = false;

    private Rigidbody2D rigidbody;
    private Vector3 velocity = Vector3.zero;
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
    private const float groundedRadius = .1f;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;

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

        // verifica colisao
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
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
        rigidbody.velocity = Vector3.SmoothDamp(rigidbody.velocity, targetVelocity, ref velocity, movementSmoothing);
        
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