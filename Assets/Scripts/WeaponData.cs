using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Game/New Weapon Data")]
public class WeaponData : ScriptableObject
{
    [Header("Stats")]
    public int maxCapacity;
    public int clipSize;
    public int ammo;
    public GameObject ammoPrefab;
    public GameObject weaponPrefab;
    public Sprite sprite;
    public bool instantiated;
    public bool unlocked;

    [Header("Shooting")]
    public Weapon weaponScript;
    public int roundsByShot;
    public float scatterAngle;
    public float shootSpeed;
    public float timeBetweenShots;
    public float reloadTime;

    [Header("HUD Display")]
    public Sprite ammoIcon;
    public Color ammoIconColor;
}
