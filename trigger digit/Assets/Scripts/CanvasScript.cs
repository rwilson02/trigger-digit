using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public PlayerScript player;
    public GunScript gun;
    public Text restraint;
    public Image hpbar, unacceptableViolence, indic;

    InnocentScript[] innoList;
    int killLimit;

    private void Start()
    {
        Time.timeScale = 1;
        player = FindObjectOfType<PlayerScript>();
        gun = player.gameObject.GetComponentInChildren<GunScript>();
        innoList = FindObjectsOfType<InnocentScript>();
        killLimit = Mathf.CeilToInt(innoList.Length * 0.70f);
        player.reputation = killLimit;
    }

    // Update is called once per frame
    void Update()
    {
        indic.fillAmount = Mathf.Lerp(0, 1, gun.timer / gun.cooldown);

        if (!gun.restraining)
        {
            if (indic.fillAmount > 0.5)
            {
                indic.color = Color.Lerp(Color.yellow, Color.green, (indic.fillAmount - .5f) * 2);
            }
            else
            {
                indic.color = Color.Lerp(Color.red, Color.yellow, indic.fillAmount * 2);
            }
        }
        else indic.color = Color.cyan;

        if (gun.restraint > 9)
        {
            restraint.text = gun.restraint.ToString("000");
        } else restraint.text = gun.restraint.ToString("00");

        unacceptableViolence.fillAmount = 1 - (player.reputation/(float)killLimit);
        hpbar.fillAmount = player.HP / 5f;
    }
}
