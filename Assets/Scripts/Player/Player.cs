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
    private InputAction fire, reload, mousePos;


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

        mousePos = playerControls.Player.MousePosition;
        mousePos.Enable();
    }

    private void OnDisable()
    {
        fire.Disable();
        reload.Disable();
        mousePos.Disable();
    }


    private void Start()
    {
        inventory = GetComponent<Inventory>();
        character.currentHealth = character.maxHealth;
    }

    private void Update()
    {
        #region Health
        if (character.currentHealth < 0)
            character.currentHealth = 0;
        else if(character.currentHealth > character.maxHealth)
            character.currentHealth = character.maxHealth;
        #endregion

        #region Hotbar
        WeaponData currentWeapon = Hotbar.GetCurrentWeapon();

        bool isShooting = fire.triggered;
        bool isReloading = reload.triggered;

        if(currentWeapon != null)
        {
            if(currentWeapon.unlocked && !currentWeapon.instantiated && GameObject.Find(currentWeapon.name) == null)
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
                    childArr[i] = weaponHandler.transform.GetChild(i).GetComponent<Weapon>().GetWeaponData();
                    if (childArr[i] != weaponToKeep)
                    {
                        childArr[i].instantiated = false;
                        Destroy(childArr[i].weaponPrefab);
                    }
                }
            }

            currentWeapon.weaponPrefab.transform.LookAt(GetMousePosition());

            if(isShooting)
            {
                currentWeapon.weaponScript.Shoot();
            }

            if(isReloading || currentWeapon.ammo % currentWeapon.clipSize != 0)
            {
                currentWeapon.weaponScript.Reload();
            }
        }
        #endregion
    }

    public void TakeDamage(int amount)
    {
        character.currentHealth -= amount;
    }

    public void Heal(int amount)
    {
        character.currentHealth += amount;
    }

    public Vector2 GetMousePosition()
    {
        return mousePos.ReadValue<Vector2>();
    }
}
