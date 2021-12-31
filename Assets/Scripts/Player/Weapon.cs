using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Animator animator;
    public float shoot_cooldown = 0.025f;
    private float last_shooted = 0f;
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Time.time - last_shooted >= shoot_cooldown)
        {
            if (Input.GetButton("Fire1"))
            {
                animator.SetBool("shooting", true);

                Shoot();
                last_shooted = Time.time;
            }
            else
            {
                animator.SetBool("shooting", false);
            }
            destruir();
        }
    }

    private void destruir()
    {
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}