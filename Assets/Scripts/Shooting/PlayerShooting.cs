using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float fireRate = 0.2f;
    public int maxAmmo = 10;
    public int damage = 10;
    public AudioSource shootSound;
    public AudioSource reloadSound;
    public AmmoManager ammoManager;

    private float nextFireTime = 0f;
    private int currentAmmo;
    private bool isReloading = false;

    void Start()
    {
        currentAmmo = maxAmmo;
        ammoManager.UpdateUI(currentAmmo, maxAmmo);
    }

    void Update()
    {
        if (isReloading) return;

        if (Input.GetMouseButton(0) && Time.time >= nextFireTime && currentAmmo > 0)
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo)
        {
            StartCoroutine(Reload());
        }
    }

    void Shoot()
    {
        nextFireTime = Time.time + fireRate;
        Bullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation).GetComponent<Bullet>();
        bullet.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
        bullet.SetDamage(damage);
        currentAmmo--;
        shootSound.Play();
        ammoManager.UpdateUI(currentAmmo, maxAmmo);
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        reloadSound.Play();
        yield return new WaitForSeconds(1f);
        currentAmmo = maxAmmo;
        ammoManager.UpdateUI(currentAmmo, maxAmmo);
        isReloading = false;
    }
}
