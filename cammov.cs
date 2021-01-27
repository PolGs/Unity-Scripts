using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cammov : MonoBehaviour
{
    public GameObject playerCurrent;
    public Camera myCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPlayerPosition = playerCurrent.transform.position;
        myCamera.transform.position = playerCurrent.transform.position+  playerCurrent.transform.forward*-5f + Vector3.up*3f;
        myCamera.transform.LookAt(currentPlayerPosition);

        //rotate player hor mov
        playerCurrent.transform.Rotate(new Vector3(Input.GetAxis("Mouse X")*180,0,0));
    }
}
