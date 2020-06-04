using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Animator animator;

    public GameObject healthDrop;

    public GameObject EnemyShot;
    public GameObject EShotSpawner;

    private float randomShot;

    float deathTime = 0.5f;

    int health = 15;

    int healthDropChance;

    // Start is called before the first frame update
    void Start()
    {
        randomShot = Random.Range(0.3f, 2f);
        deathTime = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        healthDropChance = Random.Range(0, 2);


        Debug.Log(healthDropChance);
        if (health <= 0)
        {
            animator.SetBool("IsDead", true);

            deathTime -= Time.deltaTime;

            if (deathTime <= 0)
            {
                if (healthDropChance == 1)
                {
                    
                    Instantiate(healthDrop, transform.position, Quaternion.identity);
                }

                BossGate.enemiesRemaining--;
                animator.SetBool("IsDead", false);
                Destroy(gameObject);
            }
        }
        
        if (randomShot <= 0)
        {
            Instantiate(EnemyShot, EShotSpawner.transform.position, Quaternion.identity);

            randomShot = Random.Range(0.3f, 2f);
        } else
        {
            randomShot -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PShot"))
        {
            health--;
        }
    }
}
