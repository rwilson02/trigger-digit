using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public KeyCode pause;
    public bool paused = false;
    //public bool pausable = false;
    public AudioSource burn;
    public GameObject pauseScreen;
    //public JukeScript music;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pause))
        {
            if (paused)
            {
                UnPause();
            }
            else
            {
                Pause();
            }

            paused = !paused;
        }
    }

    public void Pause()
    {
        //music.sauce.Pause();
        burn.Pause();
        pauseScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        pauseScreen.SetActive(false);
        //music.sauce.UnPause();
        burn.UnPause();
    }
}
