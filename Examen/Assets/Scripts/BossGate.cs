using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGate : MonoBehaviour
{
    public Collider2D collider;

    public GameObject closed;
    public GameObject opened;

    public static int enemiesRemaining;

    public AudioSource emisorAudio;
    public AudioClip door;

    // Start is called before the first frame update
    void Start()
    {
        opened.SetActive(false);
        closed.SetActive(true);

        enemiesRemaining = 7;

        emisorAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesRemaining == 0)
        {
            enemiesRemaining = 1;

            DoorSound();


            opened.SetActive(true);
            closed.SetActive(false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DoorSound();

            collider.enabled = false;

            opened.SetActive(false);
            closed.SetActive(true);
        }
    }
    public void DoorSound()
    {
        emisorAudio.PlayOneShot(door);

    }

}
