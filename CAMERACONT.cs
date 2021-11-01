using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAMERACONT : MonoBehaviour
{
        public float minX = -60f;
        public float maxX = 60f;
        public float speed = 0.2f;
        public float sensitivity = 1;
        public Camera cam;

        float rotY = 0f;
        float rotX = 0f;
   
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        rotY += Input.GetAxis("Mouse X") * sensitivity;
        rotX += Input.GetAxis("Mouse Y") * sensitivity;

        rotX = Mathf.Clamp(rotX, minX, maxX);
       

      
        cam.transform.localEulerAngles = new Vector3(-rotX, rotY, 0);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Mistake happened here vvvv
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Cursor.visible && Input.GetMouseButtonDown(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }






        float xAxisValue = Input.GetAxis("Horizontal");
        float zAxisValue = Input.GetAxis("Vertical");
        if (Camera.current != null)
        {
            Camera.current.transform.Translate(new Vector3(xAxisValue* speed, 0.0f, zAxisValue * speed));
        }

    }
}
