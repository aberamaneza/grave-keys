using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class exit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuitGame()
    {
        // This will quit the application when called
        // Note: In the Unity Editor, this might stop the Play mode.
        // In a built executable, it will close the application.
        Application.Quit();
    }
    public void changee()
    {
        SceneManager.LoadScene("yhg");

    }
}
