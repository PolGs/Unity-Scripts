using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerPol : MonoBehaviour
{
    public WheelCollider FR;
    public WheelCollider FL;
    public WheelCollider RR;
    public WheelCollider RL;

    public Transform FR_tr;
    public Transform FL_tr;
    public Transform RR_tr;
    public Transform RL_tr;
    // Start is called before the first frame update

    public float steer_max = 20;
    public float motor_max;
    public float brake_max;

    private float steer = 0;
    private float motor = 0;
    private float brake = 0;

    public bool isAWD = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        steer = Mathf.Clamp(Input.GetAxis("Horizontal"), -1, 1);
        motor = Mathf.Clamp(Input.GetAxis("Vertical"), -1, 1);
       
        //set tourque tocontrollers
        RR.motorTorque = motor_max * motor;
        RL.motorTorque = motor_max * motor;
        if (isAWD)
        {
            FR.motorTorque = motor_max * motor;
            FL.motorTorque = motor_max * motor;
        }
        //rotate transfoprms
        Vector3 pos;
        Quaternion ang;
        RR.GetWorldPose(out pos, out ang);
        RR_tr.transform.rotation = ang;
        RL_tr.transform.rotation = ang;



        if (Input.GetKey("space"))
        {
            RR.brakeTorque = brake_max;
            RL.brakeTorque = brake_max;
        }
        else
        {
            RR.brakeTorque = 0;
            RL.brakeTorque = 0;
        }
        

        //collider angle
        FR.steerAngle = steer_max * steer;
        FL.steerAngle = steer_max * steer;
        //transform angle get collider and set to transform
        FR.GetWorldPose(out pos, out ang);
        FR_tr.transform.rotation = ang;
        FL_tr.transform.rotation = ang;




    }
}
