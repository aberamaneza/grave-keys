using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    [SerializeField] public LayerMask PickupMask;
    [SerializeField] public Camera PlayerCam;
    [SerializeField] public Transform PickupTarget;
    [Space]
    [SerializeField] private float PickupRange;
    public Rigidbody CurrentObject;
    private bool x = false;
    public float MaxInteractDistance;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (CurrentObject)
            {


                CurrentObject.useGravity = true;
                CurrentObject = null;
                return;
            }

            Ray CameraRay = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            Ray CameraRay1 = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, PickupMask))
            {
                if (Vector3.Distance(transform.position, HitInfo.collider.transform.position) <= MaxInteractDistance)
                {
                    CurrentObject = HitInfo.rigidbody;
                    CurrentObject.useGravity = false;
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (CurrentObject)
        {
            Vector3 DirectionToPoint = PickupTarget.position - CurrentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;
            CurrentObject.velocity = DirectionToPoint * 12f * DistanceToPoint;
        }
    }
}
