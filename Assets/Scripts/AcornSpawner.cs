using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public float spawn_cooldown;
    public GameObject acorn;
    // Start is called before the first frame update
    private float spawn_time = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Camera.main.transform.position.x + 15, transform.position.y, 0);
        if(Time.time - spawn_time >= spawn_cooldown){
            spawn_time = Time.time;
            Instantiate(acorn, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
