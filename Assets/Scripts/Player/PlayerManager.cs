using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private bool input_enabled = true;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private GameObject playerObj;
    public GameObject tiro;
    public GameObject dying;
    public float shoot_cooldown = 0.025f;
    public GameObject bullet_spawner;
    
    private float last_shooted = 0;
    private bool running = false;
    private bool jumping = false;
    private float ground;
    private float baseHeight;
    private float jumpSpeed = 0;

    [Header("Variaveis")] [SerializeField] public float velX = 5f;

    [SerializeField] public float velY = 5f;

    [SerializeField] public float weight = 19f;

    [SerializeField] public float jumpImpulse = 14f;

    IEnumerator RestartLevel(){
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level 1");
    }

    void End(){
        GameObject.Find("Bravo").GetComponent<SpriteRenderer>().enabled = true;
        input_enabled = false;
    }

    void Die(){
        Instantiate(dying, transform.position + transform.up * 0.7f, Quaternion.identity);
        StartCoroutine(RestartLevel());
        gameObject.transform.localScale = new Vector3(0,0,0);
        velX = 0;
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerObj = GameObject.FindGameObjectWithTag("Player");
        GameObject.Find("Bravo").GetComponent<SpriteRenderer>().enabled = false;

        weight = 19f;
        jumpImpulse = 20f;
        ground = transform.position.y;
        baseHeight = ground;
    }

    void Update()
    {
        if(input_enabled){
            Movimentacao();
            Atirar();
        }
    }

    public void Movimentacao()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!jumping)
            {
                animator.SetBool("running", true);
            }

            running = true;
            spriteRenderer.flipX = false;
            transform.position += transform.right * velX * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && (transform.position.x - (velX * Time.deltaTime) >= -10))
        {
            if (!jumping)
            {
                animator.SetBool("running", true);
            }

            running = true;
            spriteRenderer.flipX = true;
            transform.position -= transform.right * velX * Time.deltaTime;
        }
        else
        {
            animator.SetBool("running", false);
            running = false;
        }

        if (Input.GetKeyDown(KeyCode.Z) && !jumping) // pular
        {
            animator.SetBool("running", false);
            jumpSpeed = jumpImpulse;
            jumping = true;
            animator.SetBool("jumping", jumping);
        }

        float multiplicadorPeso = 2.5f;
        if (jumping)
        {
            transform.position += transform.up * jumpSpeed * Time.deltaTime;
            jumpSpeed -= weight * multiplicadorPeso * Time.deltaTime;
            multiplicadorPeso = 2.5f;

            float height = transform.position.y - baseHeight;

            if (height < 0.0001f)
            {
                jumping = false;
                transform.position = new Vector2(transform.position.x, baseHeight);
                animator.SetBool("jumping", jumping);
                if (running == true)
                {
                    animator.SetBool("running", true);
                }
            }
        }
    }

    public void Atirar()
    {
        if (Input.GetKey(KeyCode.X))
        {
            if (Time.time - last_shooted >= shoot_cooldown){
                animator.SetBool("shooting", true);
                GameObject tiro = Object.Instantiate(this.tiro, new Vector3 (transform.position.x, transform.position.y + 0.8f, 0), Quaternion.identity);
                bullet_spawner.GetComponent<SpriteRenderer>().enabled = true;
                if (spriteRenderer.flipX)
                    tiro.GetComponent<SpriteRenderer>().flipX = true;
                last_shooted = Time.time;
            }     
        }
        else
        {
            animator.SetBool("shooting", false);
            bullet_spawner.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
        else if(other.gameObject.CompareTag("Platform") && jumpSpeed < -5){
            Collider2D box = other.GetComponent<Collider2D>();
            baseHeight = box.bounds.max.y + box.bounds.extents.y - 0.7f;
        }else if(other.gameObject.CompareTag("Goal")){
            End();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Platform")){
            baseHeight = ground;
            jumping = true;
        }
    }
}