using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basic : MonoBehaviour
{
    Rigidbody rb;

    private float xInput, yInput;

    public float mms;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mms = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void FixedUpdate() {
        Movement();    
    }


    private void GetInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }

    private void Movement()
    {
        rb.AddForce(xInput * mms, 0 , yInput * mms);
    }
}
