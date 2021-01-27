using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raptorwings : MonoBehaviour
{
    public Transform leftWingTransform;
    public Transform rightWingTransform;

    private bool wings = true;
    // Start is called before the first frame update
    void Start()
    {
        leftWingTransform.transform.Rotate(0, 0, -90);
        rightWingTransform.transform.Rotate(0, 0, 90);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("1"))
        {
            if (wings)
            {
                leftWingTransform.transform.Rotate(0, 0, 90);
                rightWingTransform.transform.Rotate(0, 0, -90);
                wings = !wings;


            }
            else
            {
                leftWingTransform.transform.Rotate(0, 0, -90);
                rightWingTransform.transform.Rotate(0, 0, 90);
                wings = !wings;
            }
        }
    }
}
