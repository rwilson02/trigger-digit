using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public PlayerScript player;
    public GunScript gun;
    public Text restraint;
    public Image hpbar, unacceptableViolence;

    InnocentScript[] innoList;
    int killLimit;

    private void Start()
    {
        innoList = FindObjectsOfType<InnocentScript>();
        killLimit = Mathf.CeilToInt(innoList.Length * 0.70f);
        player.reputation = killLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if(gun.restraint > 9)
        {
            restraint.text = gun.restraint.ToString("000");
        } else restraint.text = gun.restraint.ToString("00");

        unacceptableViolence.fillAmount = 1 - (player.reputation/(float)killLimit);
        hpbar.fillAmount = player.HP / 5f;
    }
}
