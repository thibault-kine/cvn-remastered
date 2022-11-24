using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [Header("Main HUD")]
    public Image ammoIcon;
    public TextMeshProUGUI points, currentAmmo, maxAmmo;

    [Header("Healthbar")]
    public Image healthbarL;
    public Image healthbarR;
    public TextMeshProUGUI healthText;

    private Player player;
    private WeaponData currentWeapon;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        currentWeapon = Hotbar.GetCurrentWeapon();

        ammoIcon.sprite = currentWeapon.ammoIcon;
        ammoIcon.color = currentWeapon.ammoIconColor;

        points.text = player.points.ToString();
        currentAmmo.text = currentWeapon.ammo.ToString();
        maxAmmo.text = currentWeapon.maxCapacity.ToString();


        healthbarL.fillAmount = player.character.currentHealth / 100f;
        healthbarR.fillAmount = player.character.currentHealth / 100f;
        healthText.text = player.character.currentHealth.ToString();
    }
}
