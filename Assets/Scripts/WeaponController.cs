using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireforce = 20f;
    public int curClip, maxClip = 10, curAmmo, maxAmmo = 100;

    public float fireRate;

    public bool canFire = true;

  

    private void Update()
    {
        
    }

    public IEnumerator Fire()
    {
        canFire = false;
        if (curAmmo > 0)
        {
            GameObject bullet =Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireforce, ForceMode2D.Impulse);
            curAmmo--;
            Debug.Log(curAmmo);
        }

        StartCoroutine(FireRateManager());
        yield return null;
    }

    public void Reload()
    {
        int reloadAmount = maxClip - curClip;
        reloadAmount = (curAmmo - reloadAmount) >= 0 ? reloadAmount : curAmmo;
        curClip += reloadAmount;
        curAmmo -= reloadAmount;
    }

    IEnumerator FireRateManager()
    {
        float timeToFireAgain = 1 / fireRate;
        yield return new WaitForSeconds(timeToFireAgain);
        canFire = true;
    }
}
