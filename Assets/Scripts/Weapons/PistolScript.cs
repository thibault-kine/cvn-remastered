using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolScript : Weapon
{
    public override WeaponData weaponData { get; set; }
    public override Transform firePoint { get; set; }


    public override void Shoot()
    {
        Debug.Log(weaponData.name + " shooting!");
    }

    public override void Reload()
    {
        Debug.Log(weaponData.name + " reloading!");
    }
}
