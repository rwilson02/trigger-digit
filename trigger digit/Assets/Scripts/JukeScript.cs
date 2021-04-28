using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JukeScript : MonoBehaviour
{
    public AudioSource sauce;
    public AudioClip inLev;
    public float vol;

    // Start is called before the first frame update
    void Start()
    {
        sauce = GetComponent<AudioSource>();
    }

    public void Jam()
    {
        sauce.Stop();
        sauce.clip = inLev;
        sauce.volume = vol;
        sauce.Play();
    }
}
