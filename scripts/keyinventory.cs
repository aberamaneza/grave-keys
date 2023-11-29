using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class keyinventory : MonoBehaviour
{   public string Scenename;
    public Text text;
    public LayerMask keyMask;
    public LayerMask pickupMask;
    public float PickupRange;
    public float MaxInteractDistance; // المسافة القصوى التي يمكن للشخصية اللاعبة التفاعل فيها
    bool yeah = false;
    public Camera PlayerCam;
    bool hide = true;
    float inv = 0;
    GameObject objectToDisappear;
    public Text text1;
    public AudioSource source1;
    public AudioSource source2;

    // Start is called before the first frame update
    void Start()
    {
        source1.enabled = false;
        source2.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {



        Ray CameraRay = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        Ray CameraRay2 = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
 
        if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, keyMask))
        {
            if (Vector3.Distance(transform.position, HitInfo.collider.transform.position) <= MaxInteractDistance)
            {
                yeah = true;
                GameObject objectToDisappear = HitInfo.collider.gameObject;
                text1.text = "Get key [E]";

                if (Input.GetKeyDown(KeyCode.E)){
                    Destroy(objectToDisappear);
                }
            }
            else
            {
                yeah = false;
                text1.text = "";
            }
        }
        else if (Physics.Raycast(CameraRay2, out RaycastHit HitInfo2, PickupRange, pickupMask)){
            if (Vector3.Distance(transform.position, HitInfo2.collider.transform.position) <= MaxInteractDistance + 3){
                text1.text = "[E]";
            }
        }
        else{
            yeah = false;
            text1.text = "";
        }
        if (inv == 7){
            source2.enabled = true;
            source2.Play();

            SceneManager.LoadScene(Scenename);


        }

        if(yeah && Input.GetKeyDown(KeyCode.E))
        {
            inv += 1;
            text.text = string.Concat(inv ," ","key found");
            hide = true;
            yeah = false;
            source1.enabled = true;
            source1.Play();
        }
        
    }
}
