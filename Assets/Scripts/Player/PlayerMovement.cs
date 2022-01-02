using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject dyingEffect;

    public PlayerController controller;
    public Animator animator;

    public float speed = 40f;
    private float horizontalMove = 0f;
    private bool jump = false;
    private bool inputEnable = true;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        if (horizontalMove == 0f)
        {
            animator.SetBool("running", false);
        }
        else
        {
            animator.SetBool("running", true);
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("jumping", true);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("jumping", false);
    }


    void FixedUpdate()
    {
        if (inputEnable)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
            jump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
        else if (other.gameObject.CompareTag("Goal"))
        {
            End();
        }

        void Die()
        {
            inputEnable = false;
            Instantiate(dyingEffect, transform.position + transform.up * 0.7f, Quaternion.identity);
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            StartCoroutine(RestartLevel());
        }

        void End()
        {
            GameObject.Find("Bravo").GetComponent<SpriteRenderer>().enabled = true;
            inputEnable = false;
            SceneManager.LoadScene(3);
        }

        IEnumerator RestartLevel()
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("Level 1");
        }
    }
}