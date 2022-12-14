using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour 
{
    public abstract void Shoot();

    public abstract void Reload();

    public abstract WeaponData GetWeaponData();

    public abstract Transform GetFirePoint();
}
