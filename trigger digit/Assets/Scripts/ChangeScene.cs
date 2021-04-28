using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string Back;
    public string Next;
    
    //Loads a given scene.
    public void Outie()
    {
        SceneManager.LoadScene(Next);
    }

    //Goes back a scene.
    public void Retreat()
    {
        SceneManager.LoadScene(Back);
    }

    //Exits the game.
    public void Escape()
    {
        Application.Quit();
    }

    //Reloads the current scene.
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
