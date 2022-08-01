using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseMenu : MonoBehaviour
{

    private bool isPaused = false;
    [SerializeField] private GameObject pauseMenu;


    private void Start()
    {
        Return();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                Pause();
            else
                Return();
        }
    }
    void Pause()
    {
        Cursor.visible = false;
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
    public void Return()
    {
        Cursor.visible = false;
        isPaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

}
