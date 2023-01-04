using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PistolScript : Weapon
{
    public WeaponData weaponData;
    public Transform firePoint;


    public override void Shoot()
    {
        //Debug.Log(weaponData.name + " shooting!");
    }

    public override void Reload()
    {
        Debug.Log(weaponData.name + " reloading!");
    }

    public override WeaponData GetWeaponData()
    {
        return weaponData;
    }

    public override Transform GetFirePoint()
    {
        return firePoint;
    }
}
