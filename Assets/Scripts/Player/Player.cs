using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public CharacterData character;
    public int points;
    public Inventory inventory;
    private PlayerInputActions playerControls;
    private InputAction fire, reload;
    public Transform weaponHolder;


    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        fire = playerControls.Player.Fire;
        fire.Enable();

        reload = playerControls.Player.Reload;
        reload.Enable();
    }

    private void OnDisable()
    {
        fire.Disable();
        reload.Disable();
    }


    private void Start()
    {
        inventory = GetComponent<Inventory>();
        character.currentHealth = character.maxHealth;
    }

    private void Update()
    {
        if(character.currentHealth < 0)
            character.currentHealth = 0;
        else if(character.currentHealth > character.maxHealth)
            character.currentHealth = character.maxHealth;


        WeaponData currentWeapon = Hotbar.GetCurrentWeapon();

        bool fireInput = fire.ReadValue<bool>();
        bool reloadInput = reload.ReadValue<bool>();


        if(currentWeapon != null)
        {
            Instantiate(currentWeapon.weaponPrefab, weaponHolder);

            if(fireInput)
            {
                currentWeapon.weaponScript.Shoot();
            }

            if(reloadInput || currentWeapon.ammo % currentWeapon.clipSize == 0)
            {
                currentWeapon.weaponScript.Reload();
            }
        }
    }

    public void TakeDamage(int amount)
    {
        character.currentHealth -= amount;
    }

    public void Heal(int amount)
    {
        character.currentHealth += amount;
    }
}
