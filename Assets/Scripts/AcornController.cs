using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornController : MonoBehaviour
{
    public float weight;
    public float speed;
    public GameObject propeller;
    public GameObject player;

    private bool falling = false;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position -= transform.right * speed * Time.deltaTime;

        if (Mathf.Abs(transform.position.x - player.transform.position.x) < 0.2f && falling == false){
                speed = 0;
				falling = true;
        		animator.SetBool("Falling", falling);
                Instantiate(propeller,transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
		}

        if (falling == true){
            transform.position -= transform.up * weight * Time.deltaTime;
        }

        if (transform.position.y < -6f){
            Destroy(gameObject);
        }
    }
}
