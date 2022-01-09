using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnerController : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<SpriteRenderer>().flipX)
        {
            transform.position = player.transform.position + new Vector3(-0.7f, 0.9f, 0);
        }
        else
        {
            transform.position = player.transform.position + new Vector3(0.7f, 0.9f, 0);
        }
    }
}
