using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class postdisable : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void disable_post(){
        postProcessVolume.enabled = false;

    }
    public void enable_post(){
        postProcessVolume.enabled = true;

    }
}
