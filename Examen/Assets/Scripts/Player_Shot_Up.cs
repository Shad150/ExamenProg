using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Player_Shot_Up : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;

    public float speed = 20;



    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        transform.rotation = Quaternion.Euler(Vector3.forward * 90);
        rigidBody2D.velocity = Vector2.up * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

}


