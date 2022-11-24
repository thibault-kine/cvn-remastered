using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<WeaponData> weapons = new List<WeaponData>();


    public void AddWeapon(WeaponData weapon)
    {
        weapons.Add(weapon);
    }
}
