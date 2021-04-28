using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToScript : MonoBehaviour
{
    public GameObject screen;
    bool toggle = false;

    public void Toggle()
    {
        if (toggle)
        {
            screen.SetActive(false);
        }
        else screen.SetActive(true);

        toggle = !toggle;
    }
}
