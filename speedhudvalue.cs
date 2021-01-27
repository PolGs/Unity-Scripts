using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speedhudvalue : MonoBehaviour
{
    public Rigidbody jetRigidBody;
    public Transform jetTransform;
    public Text velocity;
    public Text altitude;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity.text =((int) jetRigidBody.velocity.magnitude).ToString();
        altitude.text = ((int)jetTransform.position.y-10).ToString();
    }
}
