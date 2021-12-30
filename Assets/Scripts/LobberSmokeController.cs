using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobberSmokeController : MonoBehaviour
{   
    IEnumerator DestroyAfterDelay(){
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       StartCoroutine(DestroyAfterDelay());
    }
}
