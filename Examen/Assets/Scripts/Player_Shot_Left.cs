using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Player_Shot_Left : MonoBehaviour
{
    public Animator animator;
    
    private Rigidbody2D rigidBody2D;

    public float speed = 20;

    float destroyTime;
    bool destroy = false;

    public Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        destroyTime =0.3f;

        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();

        rigidBody2D.velocity = Vector2.left * speed;
    }

    // Update is called once per frame
    void Update()
    {

        if (destroy == true)
        {
            destroyTime -= Time.deltaTime;
            rigidBody2D.velocity = Vector2.zero;
            collider.enabled = false;
        }

        if (destroyTime <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EShot"))
        {

        } else
        {
            destroy = true;

            animator.SetBool("Impact", true);

        }
    }

}