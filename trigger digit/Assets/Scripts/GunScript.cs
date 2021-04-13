using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Camera cam;
    public Transform muzzle;
    public GameObject bulletPrefab;
    public float DMG = 10f;
    public float range = 100f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot(bool restrain = false)
    {
        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
        bullet.transform.forward = cam.transform.forward;
    }
}
