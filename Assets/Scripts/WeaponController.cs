using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireforce = 20f;
    public int curClip, maxClip = 10, curAmmo, maxAmmo = 100;

    public float fireRate = 1;
    public float nextFire = 10f;

 

    public PlayerJoyStick shootJoystick;
    public float joystickShootEdge;


    private void Update()
    {

        if (Mathf.Abs(shootJoystick.inputDir.x) > joystickShootEdge && Time.time > nextFire || Mathf.Abs(shootJoystick.inputDir.y) > joystickShootEdge && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
    }

    public void Fire()
    {
        if (curAmmo > 0)
        {
            GameObject bullet =Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireforce, ForceMode2D.Impulse);
            curAmmo--;
            Debug.Log(curAmmo);
        }
    }

    public void Reload()
    {
        int reloadAmount = maxClip - curClip;
        reloadAmount = (curAmmo - reloadAmount) >= 0 ? reloadAmount : curAmmo;
        curClip += reloadAmount;
        curAmmo -= reloadAmount;
    }


}
