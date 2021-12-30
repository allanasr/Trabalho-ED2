using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChomperSpawner : MonoBehaviour
{
    public float spawn_cooldown; //Cooldown do spawn do Chomper
    public GameObject chomper; //Prefab do Chomper
    private float spawn_time = 0;//Tempo do último spawn para comparação;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Se o tempo de spawn foi atingido
        if(Time.time - spawn_time >= spawn_cooldown){
            spawn_time = Time.time; //Atualiza o tempo do último spawn com o spawn atual
            Instantiate(chomper, transform.position + new Vector3(0, 0, 0), Quaternion.identity); //Cria um novo Chomper
        }
    }
}
