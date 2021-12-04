using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyDaisyController : MonoBehaviour
{
    public float speed;
    public float range;
    private float initial_pos;
    private GameObject player;
    private int direction = -1;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        initial_pos = transform.position.x;
        sprite = GetComponent<SpriteRenderer>();
    }
    
    void FixedUpdate()
    {
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
}
