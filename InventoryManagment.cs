using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManagment : MonoBehaviour
{
    public GameObject thirdPersonPack;
    public GameObject armoredTruck;
    public InventoryObject inventory;
    public Camera cam;
    public Camera jetFpsCam;
   
    void Awake()
    {
        jetFpsCam.enabled = false;
    }



    // Update is called once per frame
    void Update()
    {
        RaycastHit whatIHit;
        Debug.DrawRay(cam.transform.position+ cam.transform.forward * 4, cam.transform.forward * 3, Color.blue);
        if (Physics.Raycast(cam.transform.position +cam.transform.forward * 4, cam.transform.forward, out whatIHit, 3) && Input.GetKeyDown("e"))
        {
            string clickedOn = whatIHit.collider.gameObject.name;
            Debug.Log(clickedOn);
            var item = whatIHit.collider.GetComponent<Item>();
            if (item)
            {
                Debug.Log("Item");
                inventory.AddItem(item.item, 1);
                Destroy(whatIHit.collider.gameObject);
            }
            if(clickedOn == "SM_Veh_Jet_01")
            {
                thirdPersonPack.SetActive(false);
                jetFpsCam.GetComponent<AudioListener>().enabled = true;
                jetFpsCam.enabled = true;
            }
            if(clickedOn == "ArmoredTruckControllerAWD")
            {
                thirdPersonPack.SetActive(false);
                armoredTruck.SetActive(true);
                
            }


            
        }
    }
}
