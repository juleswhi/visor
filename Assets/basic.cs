using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basic : MonoBehaviour
{
    Rigidbody rb;

    public CharacterController controller;

    private float xInput, zInput;

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
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xInput + transform.forward * zInput;

        controller.Move(move);
    }




}
