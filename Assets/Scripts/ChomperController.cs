using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChomperController : MonoBehaviour
{
    public float speed;
    public float gravity;

    private bool bite = false;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        speed -= gravity;
        if (speed <= 2f && bite == false){
            bite = true;
            animator.SetBool("Bite", bite);
        }

        if(transform.position.y < -6f && bite)
            Destroy(gameObject);
    }
}
