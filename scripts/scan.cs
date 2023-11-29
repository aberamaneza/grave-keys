using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scan : MonoBehaviour
{   
    public Camera game;
    public Text text;

    public LayerMask keyMask;
    public float PickupRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray CameraRay = game.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
 
        if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, keyMask))
        {
            text.text = "booom";

        }
    }
}
