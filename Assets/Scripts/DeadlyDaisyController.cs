using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyDaisyController : MonoBehaviour
{
    public float speed;
    public float range;
    public float life = 1;
    public GameObject dying;
    private float initial_pos;
    private GameObject player;
    private int direction = -1;
    private SpriteRenderer sprite;

    void TakeDamage(){
        life--;
    }

    void Die(){
        Instantiate(dying, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        initial_pos = transform.position.x;
        sprite = GetComponent<SpriteRenderer>();
    }
    
    void FixedUpdate()
    {
        if(life <= 0)
        {
            Die();
        }

        if(transform.position.x >= initial_pos + range || transform.position.x <= initial_pos - range)
        {
            direction *= -1;
        }

        if(direction == 1)
        {
            transform.position += transform.right * speed * Time.deltaTime;
            sprite.flipX = true;
        }else{
            transform.position -= transform.right * speed * Time.deltaTime;
            sprite.flipX = false;
        }
    }

    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage();
        }
            direction *= -1; // todo: pq ao encostar em um objeto nao muda a direcao?
        
    }
}
