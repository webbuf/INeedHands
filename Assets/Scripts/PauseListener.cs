using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseListener : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Unpause();
            }
            else 
            {
                Pause();
            }
        }
    }

    public void Pause() {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
        isPaused = true;
        Cursor.visible = true;
    }
    public void Unpause() {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        isPaused = false;
        Cursor.visible = false;
    }

    public void Exit() {
        Application.Quit();
    }
}
