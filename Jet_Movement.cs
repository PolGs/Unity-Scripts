using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jet_Movement : MonoBehaviour
{
 
    private float aspectRatio;
    public Transform jetTransform;
    public Rigidbody rb;
    public WheelCollider frontWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;
    public float motorForce = 200f;
    public float brakeForce = 0f;
    public Transform cam;
    public Camera camObj;
    
    public ParticleSystem explosion;

    public bool wheels = true;
    private float maxSteeringAngle = 10f;
    private float horizontalInput;
    private float verticalInput;
    private float scrollInput;
    private float steerAngle;
    private bool isBreaking;
    private float thrust = 0;
    private bool perspective;
    

    // Start is called before the first frame update
    void Start()
    {
        rb.centerOfMass = new Vector3(0, 0, 0);
        explosion.Pause();

       

    }



    private void GetInput()
    {
        //get input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput > 0f) thrust += 1;
        if (scrollInput < 0f && thrust != 0) thrust -= 1;
    }
    private void HandleWheels()
    {

        //hande steering
        steerAngle = maxSteeringAngle * horizontalInput;
        frontWheelCollider.steerAngle = steerAngle;

        //handle motor
        rearLeftWheelCollider.motorTorque = thrust * motorForce;
        rearRightWheelCollider.motorTorque = thrust* motorForce;
    }

    void OnCollisionEnter(Collision collision)
    {
        explosion.Play();
        thrust = 0;
    }



    // Update is called once per frame
    void Update()
    {
        GetInput();
        //Controls
        if (Input.GetKeyDown("h"))
        {
            wheels = !wheels;
        
        }
        if (Input.GetKeyDown("f5"))
        {
         
            perspective = !perspective;
        }

        

        //control handling
        //--Physics--
        if (wheels)
        {
            
            HandleWheels();
        }
        else
        {

            //jetTransform.transform.position += jetTransform.transform.forward * Time.deltaTime * thrust ;
           //Jet Power
            rb.AddForce(jetTransform.transform.forward* Time.deltaTime *600 * thrust,ForceMode.Acceleration);
            //wings
            if(rb.velocity.y < 0 && rb.velocity.y < 0) {
                rb.AddForce(jetTransform.transform.forward * Time.deltaTime * 9000 * -rb.velocity.y);
                    }

            //jetTransform.transform.Rotate(-verticalInput*0.4f, 0, -horizontalInput*0.7f);
            if(rb.velocity.magnitude < 100)
            {
                rb.AddTorque(jetTransform.transform.right * -verticalInput * Time.deltaTime * 7000 * rb.velocity.magnitude);
                rb.AddTorque(jetTransform.transform.forward * -horizontalInput * Time.deltaTime * 4000*rb.velocity.magnitude);
            }
            else
            {
                rb.AddTorque(jetTransform.transform.right * -verticalInput * Time.deltaTime * 300000);
                rb.AddTorque(jetTransform.transform.forward * -horizontalInput * Time.deltaTime * 200000);
            }
           
            if (Input.GetKey("q")) transform.Rotate(0, -0.1f, 0);
            if (Input.GetKey("e")) transform.Rotate(0, 0.1f, 0);

            if(thrust != 0) rb.velocity = rb.velocity.magnitude * jetTransform.transform.forward;
            
            
        }

        //Camera
        if (perspective)
        {
            camObj.enabled = true;
            Vector3 moveCamTo = jetTransform.transform.position - jetTransform.transform.forward * 20f + Vector3.up * 3f;
            cam.transform.position = moveCamTo;
            cam.transform.LookAt(jetTransform.transform.position);
        }
        else
        {
            camObj.enabled = false;
        }


        



    }
}
