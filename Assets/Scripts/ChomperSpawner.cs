using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChomperSpawner : MonoBehaviour
{
    public float spawn_cooldown;
    public GameObject chomper;
    // Start is called before the first frame update
    private float spawn_time = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - spawn_time >= spawn_cooldown){
            spawn_time = Time.time;
            Instantiate(chomper, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
