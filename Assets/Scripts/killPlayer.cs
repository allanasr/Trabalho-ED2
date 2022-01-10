using UnityEngine;
using System.Collections;

public class killPlayer : MonoBehaviour
{
    public PlayerMovement controller;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        controller.Die();
    }
}