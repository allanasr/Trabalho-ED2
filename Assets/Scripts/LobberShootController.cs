using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobberShootController : MonoBehaviour
{
    public float time_to_arrive;
    public float arc_height;
    public GameObject smoke;

    private float speed;
    private GameObject player;
    private Vector3 start_pos;
    private Vector3 player_pos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        start_pos = transform.position;
        player_pos = player.transform.position - new Vector3(0, 0.3f, 0);
        speed = Mathf.Abs((player_pos.x - start_pos.x)/time_to_arrive);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x0 = start_pos.x;
        float x1 = player_pos.x;
        float distance = x1 - x0;
        float next_x = Mathf.MoveTowards(transform.position.x, x1, speed * Time.deltaTime);
        float base_y = Mathf.Lerp(start_pos.y, player_pos.y, (next_x - x0)/distance);
        float arc = arc_height * (next_x - x0) * (next_x - x1) / (-0.25f * distance * distance);
        Vector3 next_pos = new Vector3(next_x, base_y + arc, transform.position.z);

        transform.position = next_pos;

        if(next_pos == player_pos){
            Instantiate(smoke, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
