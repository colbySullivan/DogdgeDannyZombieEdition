using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGun : MonoBehaviour
{
    public float Damage;
    public float BulletRange;

    public Transform gun;

    public Vector3 upRecoil;
    Vector3 originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        originalRotation = gun.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 1000, Color.green);
    }

    public void StopRecoil()
    {
        gun.localEulerAngles = originalRotation;
    }

    public void AddRecoil()
    {
        gun.localEulerAngles += upRecoil;
    }

    public void Shoot()
    {
        Ray gunRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if(Physics.Raycast(gunRay, out RaycastHit hitInfo, BulletRange))
        {
            if(hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))
            {
                enemy.Health -= Damage;
            }
        }
    }
}