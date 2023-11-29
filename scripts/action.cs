using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovment : MonoBehaviour
{   public CharacterController controller;
    // Start is called before the first frame update

    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform checkground;
    public float grounddistance = 0.4f;
    public LayerMask groundmask;
    bool isgrounded;
    public float jumpheight = 3f;
    Vector3 velocity;
    
    // Update is called once per frame
    void Update()
    {
        isgrounded = Physics.CheckSphere(checkground.position,grounddistance,groundmask);
        if(isgrounded && velocity.y < 0){

            velocity.y = -2f;
        }

        if(Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2*gravity);
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}

