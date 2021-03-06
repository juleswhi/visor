using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basic : MonoBehaviour
{
    Rigidbody rb;
    public float airAccelaration;
    public CharacterController controller;
    public Transform groundCheck;
    private Vector3 velocity;
    private float xInput, zInput, gravity;
    public float mms, groundDistance, jumpHeight;
    public LayerMask groundMask;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        AssignValues();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
            velocity.y = -2f;
        if(isGrounded)
            velocity.x = 0f;



        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        if(Input.GetButtonDown("Horizontal") && !isGrounded)
        {
          airAccelaration += airAccelaration;
        }

        Vector3 move = transform.right * xInput + transform.forward * zInput;
        controller.Move(move * mms * airAccelaration * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        if(isGrounded)
            airAccelaration = 1f;

        Debug.Log($"Air Accelarastion: {airAccelaration}, move: {move}");
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }


    private void AssignValues()
    {
        rb = GetComponent<Rigidbody>();
        mms = 10f;
        gravity = -25f;
        groundDistance = 0.4f;
        jumpHeight = 6.5f;
        airAccelaration = 1f;
    }




}
