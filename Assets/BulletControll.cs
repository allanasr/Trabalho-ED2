using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControll : MonoBehaviour
{  
    public float speed = 3f;
    public float delay_death;
    private Animator animator;
    private bool flipped = false;
    private SpriteRenderer sprite;


    IEnumerator DestroyAfterDelay(){
        yield return new WaitForSeconds(delay_death);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        if(sprite.flipX)
            flipped = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(flipped){
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }

        if(Mathf.Abs(transform.position.x - Camera.main.transform.position.x) > 12f)
           Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy"))
        {
            animator.SetBool("Death", true);
            gameObject.GetComponent<Collider2D>().enabled = false;;
            speed = 0;
            StartCoroutine(DestroyAfterDelay());
        }
    }
}
