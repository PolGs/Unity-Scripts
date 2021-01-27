using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;




//Used to rotate Character when you look arround
public class CharacterAiming : MonoBehaviour
{

    public float turnSpeed = 15f;
    public Camera mainCam;
    public Rig aimlayer;
    public AudioSource shotSound;
    public bool aiming = false;
    RayCastWeapon weapon;


    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponentInChildren<RayCastWeapon>();

    }

    // Update is called once per frame
    void Update()
    {
        float yawCam = mainCam.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCam, 0), turnSpeed * Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {

      


        if (Input.GetMouseButton(1)) aiming = true;
        else aiming = false;


            if (aiming)
            {
                aimlayer.weight += Time.deltaTime*4;
                
            }
            else{
                aimlayer.weight -= Time.deltaTime*4;
            }


        if (Input.GetMouseButtonDown(0) && aiming)
        {

            weapon.StartFiring();
            shotSound.Play(0);


        }

        if (Input.GetMouseButtonUp(0) && aiming)
        {
            weapon.StopFiring();

        }



    }
}
