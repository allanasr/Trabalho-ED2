using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float speed = 10.0f;
    public float verticalSpeed = 5.0f;

    private float gravity = -1.0f;
    private float dx;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        dx = Input.GetAxis("Horizontal");
    


        transform.Translate(new Vector3(dx * speed * Time.deltaTime, gravity));

        if(Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(new Vector2(dx * speed * Time.deltaTime, verticalSpeed * gravity * Time.deltaTime));
        }

    }
}
