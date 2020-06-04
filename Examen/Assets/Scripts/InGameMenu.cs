using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject controls;
    public GameObject pauseMenu;
    public GameObject deadMenu;

    void Start()
    {
        controls.SetActive(true);
        Time.timeScale = 0;

        pauseMenu.SetActive(false);
        deadMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

        if (PlayerMovement.deadMenu == true)
        {
            deadMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Dismiss()
    {
        Time.timeScale = 1;

        controls.SetActive(false);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);

    }

    public void Exit()
    {
        SceneManager.LoadScene("StartMenu");
    }

}
