using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWeapon : MonoBehaviour
{
    public bool isFiring = false;
    public ParticleSystem muzzleFlash;
    public ParticleSystem hitEffect;
    public Transform raycastorigin;
    public Transform raycastdest;


    Ray ray;
    RaycastHit hitInfo;


    public void StartFiring()
    {
        isFiring = true;
        muzzleFlash.Emit(1);

        ray.origin = raycastorigin.position;
        ray.direction = raycastdest.position - raycastorigin.position;

        if(Physics.Raycast(ray, out hitInfo)){
            hitEffect.transform.position = hitInfo.point;
            hitEffect.transform.forward = hitInfo.normal;
            hitEffect.Emit(1);
            if (hitInfo.collider.GetComponent<Rigidbody>() != null)
            {
                var mass = hitInfo.collider.GetComponent<Rigidbody>();
                mass.AddForce(ray.direction * 100);
            }
        }
    }

    public void StopFiring()
    {
        isFiring = false;
    }
}
