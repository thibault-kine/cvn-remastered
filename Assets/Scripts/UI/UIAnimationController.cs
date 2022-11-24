using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIAnimationController : MonoBehaviour
{
    [Header("Hotbar Animation")]
    public Animator hotbarAnim;

    private PlayerInputActions playerControls;
    private InputAction scroll;


    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        scroll = playerControls.Player.HotbarScroll;
        scroll.Enable();
    }

    private void OnDisable()
    {
        scroll.Disable();
    }

    private void Update()
    {
        float scrollValue = scroll.ReadValue<float>();
        hotbarAnim.SetFloat("ScrollValue", scrollValue);
    }
}
