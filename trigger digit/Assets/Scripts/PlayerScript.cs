using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : HumanoidScript
{
    PauseManager pausy;
    public Text pauseTitle;
    public GameObject pauseSub;

    private void Start()
    {
        pausy = FindObjectOfType<PauseManager>();
    }

    override public void Die(PlayerScript from = null)
    {
        pausy.Pause();
        pauseTitle.color = Color.red;
        pauseTitle.text = "YOU DIED";
        pauseSub.SetActive(false);
    }

    public void FeelBadAbtIt()
    {
        reputation--;

        if(reputation == 0)
        {
            Murderer();
        }
    }

    public void Murderer()
    {
        pausy.Pause();
        pauseTitle.color = Color.red;
        pauseTitle.text = "TOO MANY INNOCENT DEATHS";
        pauseSub.SetActive(false);
    }
}
