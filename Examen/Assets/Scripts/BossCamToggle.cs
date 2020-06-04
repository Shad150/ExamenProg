using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossCamToggle : MonoBehaviour
{
    public GameObject bossCam;
    public GameObject theEnd;

    public Collider2D colliderb;

    public AudioSource emissor;
    public AudioClip endSound;

    bool end = false;

    float timer= 5f;
    float timer2= 8f;

    private void Start()
    {
        theEnd.SetActive(false);
    }

    private void Update()
    {
        Debug.Log(timer);
        Debug.Log(timer2);

        if (end == true)
        {
            timer -= Time.deltaTime;
            timer2 -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            EndSound();
            theEnd.SetActive(true);
        }

        if (timer2 <= 0)
        {
            SceneManager.LoadScene("StartMenu");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            end = true;

            bossCam.SetActive(true);

            colliderb.enabled= false;
        }
    }

    public void EndSound()
    {
        emissor.PlayOneShot(endSound);

    }

}
