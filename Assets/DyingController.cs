using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingController : MonoBehaviour
{
    public float delay_death;

    IEnumerator DestroyAfterDelay(){
        yield return new WaitForSeconds(delay_death);
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
