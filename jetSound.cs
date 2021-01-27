using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jetSound : MonoBehaviour
{
    public AudioSource a;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.magnitude < 80)
        a.pitch = rb.velocity.magnitude*0.05f;
    }
}
