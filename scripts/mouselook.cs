using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class mouselook : MonoBehaviour
{
    [SerializeField] mousesencivity moi;
    private float mouseSensitivity;
    //[SerializeField]

    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        mouseSensitivity += moi.dgf.value;

        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    

    
    void Update()
    {

        Debug.Log(moi.dgf.value);
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the camera vertically (around the X-axis)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);  // Apply vertical rotation to the camera

        // Rotate the player horizontally (around the Y-axis)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
