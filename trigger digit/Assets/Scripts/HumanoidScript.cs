using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidScript : MonoBehaviour
{
    public int HP = 3;
    public int reputation = 3;

    public void Hit()
    {
        HP--;

        if(HP == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        print("lol bye, from " + gameObject.name);
        gameObject.SetActive(false);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Bullet"))
        {
            print("POW");
            Hit();
            Destroy(hit.collider.gameObject);
        }
    }
}
