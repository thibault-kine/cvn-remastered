using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour 
{
    public abstract WeaponData weaponData { get; set; }
    public abstract Transform firePoint { get; set; }

    public abstract void Shoot();

    public abstract void Reload();
}
