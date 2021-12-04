using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikerController : MonoBehaviour
{
    public float speed;
    public float frequency;
    public float phaseOffset;
    // Start is called before the first frame update
    void Start()
    {

    }
    
    void FixedUpdate()
    {
        transform.position += transform.up * Mathf.Sin(Time.time * frequency / Mathf.PI + phaseOffset) * speed;
    }
}
