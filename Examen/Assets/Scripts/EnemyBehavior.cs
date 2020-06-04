using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Animator animator;

    public AudioSource emisorAudio;
    public AudioClip enemyShot;
    public AudioClip enemyDeath;

    public GameObject healthDrop;

    public GameObject EnemyShot;
    public GameObject EShotSpawner;

    private float randomShot;

    float deathTime = 0.5f;

    int health = 15;

    int healthDropChance;


    void Start()
    {
        randomShot = Random.Range(0.3f, 2f);
        deathTime = 0.5f;
    }

    void Update()
    {
        healthDropChance = Random.Range(0, 2);

        if (health <= 0)
        {
            animator.SetBool("IsDead", true);
            emisorAudio.PlayOneShot(enemyDeath);

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
            emisorAudio = GetComponent<AudioSource>();
            ShotSound();

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

    public void ShotSound()
    {
        emisorAudio.PlayOneShot(enemyShot);
    }
}
