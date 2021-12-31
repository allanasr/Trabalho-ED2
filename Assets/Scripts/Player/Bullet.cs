using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Animator animator;
    public float speed = 20f;
    public int damage;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    private GameObject effect; // TODO: resolver destruicao dos efeitos


    void Start()
    {
        animator = GetComponent<Animator>();
        rb.velocity = transform.right * speed;
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(transform.position.x - Camera.main.transform.position.x) > 12f)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Enemy enemy = col.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
        // effect = Instantiate(impactEffect, transform.position, transform.rotation);
        
    }
    
    
}