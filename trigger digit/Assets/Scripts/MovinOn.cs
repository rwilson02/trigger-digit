using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovinOn : MonoBehaviour
{
    ChangeScene sean;

    // Start is called before the first frame update
    void Start()
    {
        sean = FindObjectOfType<ChangeScene>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sean.Outie();
        }
    }
}
