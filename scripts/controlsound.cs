using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controlsound : MonoBehaviour
{
    public Slider sfx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changescen(){
        SceneManager.LoadScene("SampleScene");

    }
    public void changsfx(){
        AudioListener.volume = sfx.value;
    }
}
