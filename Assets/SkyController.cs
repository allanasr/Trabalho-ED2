using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Mantém o céu parado em relação à câmera
        transform.position = new Vector3(Camera.main.transform.position.x, transform.position.y, 0);
    }
}
