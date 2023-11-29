using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movee : MonoBehaviour
{   public CharacterController controller;
    // Start is called before the first frame update
    public float speed = 13f;
    public float gravity = -9.81f;
    public Transform checkground;
    public Transform checkground2;
    public AudioSource source2;
    public float grounddistance = 0.4f;
    public LayerMask groundmask;
    public LayerMask groundmask2;
    bool isgrounded;
    bool isgrounded2;
    public float jumpheight = 3f;
    Vector3 velocity;

    void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        isgrounded = Physics.CheckSphere(checkground.position,grounddistance,groundmask);
        isgrounded2 = Physics.CheckSphere(checkground2.position,grounddistance,groundmask2);

        if(isgrounded && velocity.y < 0){

            velocity.y = -2f;
        }



        if(Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2*gravity);
        }
        if(Input.GetKeyDown(KeyCode.Space) && isgrounded2)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2*gravity);
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 25;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 13;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        Vector3 movement = new Vector3(x, 0f, z);
        if (movement.magnitude > 0.1f){
            source2.enabled = true;
            //source2.enabled = false;

        }else{
            source2.enabled = false;
            //source2.enabled = false;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


    }
}
