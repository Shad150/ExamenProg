using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]


public class Enemy_Shot : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;

    public float speed = 10;

    void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();

        rigidBody2D.velocity = Vector2.left * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.CompareTag("Enemy"))
        {

        } else if (collision.otherCollider.CompareTag("PShot"))
        {

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
