using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    //Right Side Switches
    public GameObject canopySwitch;
    public GameObject batterySwitch;
    public GameObject landingSwitch;


    //Jet flaps and cnaopy
    public GameObject canopy;
    public GameObject lwFlap;
    public GameObject rwFlap;
    public GameObject landingGearR;
    public GameObject landingGearL;
    public GameObject landingGearF;

    public int mouseSensitivity = 5;
    public Camera cam;
    RaycastHit whatIHit;

    private float rotationX = 0;
    private float rotationY=0;
    private bool canopyBool, landingGearBool;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       

        rotationX += Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationY += Input.GetAxis("Mouse Y") * mouseSensitivity;
        

        cam.transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);


        //Cockpit buttons
        Debug.DrawRay(cam.transform.position, cam.transform.forward * 1, Color.blue);
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out whatIHit, 1) && Input.GetKeyDown("f"))
        {
           string clickedOn =  whatIHit.collider.gameObject.name;
           
           if(clickedOn == "Canopy_Switch")
            {
                Debug.Log("canopy");
                if (canopyBool)
                {
                    canopySwitch.transform.Rotate(80, 0, 0);
                    canopy.transform.Rotate(0, 90, 0);
                    
                }
                else
                {
                    canopySwitch.transform.Rotate(-80, 0, 0);
                    canopy.transform.Rotate(0, -90, 0);
                    
                }
                canopyBool = !canopyBool;
            }
            if (clickedOn == "LandingGear")
            {
                Debug.Log("landingGear");
                if (landingGearBool)
                {
                    landingSwitch.transform.Rotate(80, 0, 0);
                    landingGearDown();
                }
                else
                {
                    landingSwitch.transform.Rotate(-80, 0, 0);
                    landingGearUp();
                }
                landingGearBool = !landingGearBool;
            }



        }



    }


    void landingGearUp()
    {
        landingGearR.transform.Rotate(-90, 0, 0);
        landingGearL.transform.Rotate(-90, 0, 0);
        landingGearF.transform.Rotate(-90, 0, 0);
    }
    void landingGearDown()
    {
        landingGearR.transform.Rotate(90, 0, 0);
        landingGearL.transform.Rotate(90, 0, 0);
        landingGearF.transform.Rotate(90, 0, 0);
    }
}
