using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornController : MonoBehaviour
{
    public float weight; // Peso do Acorn
    public float speed; // Velocidade lateral do Acorn
    public GameObject propeller; // Objeto para a hélice que se separa do Acorn na queda
    public GameObject player; // Objeto para o jogador

    private bool falling = false; // Determina se o Acorn está caindo
    private Animator animator; // Animator do Acorn

    // Start is called before the first frame update
    // Seleciona o Animator do Acorn e determina qual objeto é o player a ser seguido
    void Start()
    {
        animator = GetComponent<Animator>(); // Seleciona o Animador
        player = GameObject.FindWithTag("Player"); // Encontra o Player
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Se move para a esquerda na tela
        transform.position -= transform.right * speed * Time.deltaTime;

        // Quando passar por cima do player, inicia o movimento de queda
        if (Mathf.Abs(transform.position.x - player.transform.position.x) < 0.2f && falling == false){
                speed = 0; // Zera a velocidade lateral do Acorn
				falling = true; // Determina que o Acorn agora está caindo
        		animator.SetBool("Falling", falling); // Inicia a animação de queda
                Instantiate(propeller,transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity); // Cria uma hélice no top do Acorn para dar a impressão que ela se separou
		}

        // Se o 
        if (falling == true){
            transform.position -= transform.up * weight * Time.deltaTime;
        }

        if (transform.position.y < -6f){
            Destroy(gameObject);
        }
    }
}
