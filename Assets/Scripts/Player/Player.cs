using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public CharacterData character;
    public int points;
    public Inventory inventory;
    public Transform weaponHandler;
    private PlayerInputActions playerControls;
    private InputAction fire, reload;


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

        float fireInput = fire.ReadValue<float>();
        float reloadInput = reload.ReadValue<float>();

        if(currentWeapon != null)
        {
            if(currentWeapon.unlocked && !currentWeapon.instantiated)
            {
                Instantiate(currentWeapon.weaponPrefab, weaponHandler);
                currentWeapon.instantiated = true;
            }

            if(weaponHandler.transform.childCount > 1)
            {
                WeaponData[] childArr = new WeaponData[weaponHandler.transform.childCount];
                WeaponData weaponToKeep = currentWeapon;

                for(int i = 0; i < childArr.Length; i++)
                {
                    childArr[i] = weaponHandler.transform.GetChild(i).GetComponent<Weapon>().weaponData;
                    if (childArr[i] != weaponToKeep)
                    {
                        childArr[i].instantiated = false;
                        Destroy(childArr[i].weaponPrefab);
                    }
                }
            }

            if(fireInput > 0)
            {
                currentWeapon.weaponScript.Shoot();
            }

            if(reloadInput > 0 || currentWeapon.ammo % currentWeapon.clipSize != 0)
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
