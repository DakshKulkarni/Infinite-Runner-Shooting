using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float bulletSpeed = 100f;
    public float fireRate = 0.5f;
    private float nextFire = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.Euler(90f, 0f, 0f));
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                bulletRigidbody.velocity = bulletSpawn.forward * bulletSpeed;
            }
            nextFire = Time.time + fireRate;
        }
    }
}
