using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRaycast : MonoBehaviour
{
    [SerializeField] private Transform marker;
    [SerializeField] private Transform armPivot;
    private Vector3 nullPosition;
    private Transform lookPivot;
    private Camera _camera;
    [SerializeField] private float distance = 300;
    private bool isAiming;


    void aiming()
    {
        Ray ray;
        RaycastHit hit;
        ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        isAiming = false;
        bool hadHit = Physics.Raycast(ray, out hit, distance);
        if (hadHit)
        {
            if (hit.transform.tag == "Target")
            {
                marker.position = hit.point;
                Vector3 vec = new Vector3(0,0,6f);
                hit.transform.localEulerAngles += vec;
                Debug.Log($"Vec {hit.transform.localEulerAngles}");
                isAiming = true;
            }

        }

        if (!isAiming && marker.transform.position != nullPosition) 
            marker.transform.position = nullPosition;
    }

    void rotateArm()
    {
        Vector3 euler;
        euler = armPivot.eulerAngles;
        //armPivot = lookPivot.eulerAngles;
        euler.x = lookPivot.eulerAngles.x;
        armPivot.eulerAngles = euler;
    }

    private void Start()
    {
        nullPosition = marker.position;
        _camera = Camera.main;
        lookPivot = _camera.transform;
    }

    private void Update()
    {
        rotateArm();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            aiming();
        }
    }
}
