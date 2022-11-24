using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
    public Animator animator;
    public Image currentWeaponImage, 
                 previousWeaponImage, 
                 nextWeaponImage;
    
    private static GameObject player;
    private PlayerInputActions playerControls;
    private static InputAction scroll;
    [SerializeField]
    private static int currIndex = 0;
    private WeaponData currentWpn;
    private RectTransform rectT;

    private void OnEnable()
    {
        scroll = playerControls.Player.HotbarScroll;
        scroll.Enable();
    }

    private void OnDisable()
    {
        scroll.Disable();
    }

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rectT = GetComponent<RectTransform>();
    }

    private void Update()
    {
        currIndex = ScrollIndexHandler();
        ManageWeapons();
    }

    private void ManageWeapons()
    {
        currentWpn = GetCurrentWeapon();

        Inventory playerInv = player.GetComponent<Inventory>();
        WeaponData[] _weapons = playerInv.weapons.ToArray();

        WeaponData prevWpn = _weapons[(currIndex - 1 < 0) ? _weapons.Length - 1 : currIndex - 1],
                   nextWpn = _weapons[(currIndex + 1 >= _weapons.Length) ? 0 : currIndex + 1];

        if (prevWpn == null)
            previousWeaponImage.sprite = null;
        else
            previousWeaponImage.sprite = prevWpn.sprite;
        previousWeaponImage.color = new Color(1, 1, 1, 0.5f);
        previousWeaponImage.SetNativeSize();

        if (currentWpn == null)
            currentWeaponImage.sprite = null;
        else
            currentWeaponImage.sprite = currentWpn.sprite;
        currentWeaponImage.color = new Color(1, 1, 1, 1);
        currentWeaponImage.SetNativeSize();

        if (nextWpn == null)
            nextWeaponImage.sprite = null;
        else
            nextWeaponImage.sprite = nextWpn.sprite;
        nextWeaponImage.color = new Color(1, 1, 1, 0.5f);
        nextWeaponImage.SetNativeSize();
    }

    public static WeaponData GetCurrentWeapon()
    {
        Inventory playerInv = player.GetComponent<Inventory>();
        WeaponData[] _weapons = playerInv.weapons.ToArray();

        return _weapons[currIndex];
    }

    private int ScrollIndexHandler()
    {
        float scrollValue = scroll.ReadValue<float>();
        Inventory playerInv = player.GetComponent<Inventory>();
        WeaponData[] _weapons = playerInv.weapons.ToArray();

        if (scrollValue > 0)
        {
            currIndex++;
        }
        if (scrollValue < 0)
        {
            currIndex--;
        }

        if (currIndex < 0)
            currIndex = _weapons.Length - 1;
        if (currIndex >= _weapons.Length)
            currIndex = 0;

        return currIndex;
    }
}
