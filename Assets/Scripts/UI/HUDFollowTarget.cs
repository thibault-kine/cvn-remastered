using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDFollowTarget : MonoBehaviour
{
    public Transform target;

    private Camera cam;
    private RectTransform rt;
    private Vector2 pos;


    private void Start()
    {
        cam = Camera.main;
        rt = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if(target)
        {
            pos = RectTransformUtility.WorldToScreenPoint(cam, target.position);
            rt.position = pos;
        }
    }
}
