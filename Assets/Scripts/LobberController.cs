using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobberController : MonoBehaviour
{
    public float range;
    public float shoot_cooldown;
    public GameObject shoot_smoke;
    public GameObject seed;
    public float life = 5;
    public GameObject dying;

    private GameObject player;
    private float shoot_time;
    private bool shooting = false;
    private Animator animator;

    IEnumerator SpawnSmokeAndSeed(){
        yield return new WaitForSeconds(1.1f);
        Instantiate(shoot_smoke, transform.position + transform.up * 2.2f, Quaternion.identity);
        Instantiate(seed, transform.position + transform.up * 1.7f, Quaternion.identity);
    }

    void TakeDamage(){
        life--;
    }

    void Die(){
        Instantiate(dying, transform.position + transform.up * 0.7f, Quaternion.identity);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        shoot_time = 0;
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0)
        {
            Die();
        }

        if (Time.time - shoot_time >= shoot_cooldown && Mathf.Abs(player.transform.position.x - transform.position.x) <= range){
            shooting = true;
            StartCoroutine(SpawnSmokeAndSeed());
            shoot_time = Time.time;
        } else {
            shooting = false;
        }
        animator.SetBool("Shooting", shooting);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Bullet"))
            TakeDamage();
    }
}
