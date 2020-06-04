using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGate : MonoBehaviour
{
    public Collider2D collider;

    public GameObject closed;
    public GameObject opened;

    public static int enemiesRemaining;

    // Start is called before the first frame update
    void Start()
    {
        opened.SetActive(false);
        closed.SetActive(true);

        enemiesRemaining = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesRemaining == 0)
        {
            opened.SetActive(true);
            closed.SetActive(false);
        }
        
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            enemiesRemaining = 1;

            opened.SetActive(false);
            closed.SetActive(true);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collider.enabled = false;
            enemiesRemaining = 1;

            opened.SetActive(false);
            closed.SetActive(true);
        }
    }
}
