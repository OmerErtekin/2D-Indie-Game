using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class MenuTutorialPanel : MonoBehaviour
{
    


    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("PlayTutorial"))
        {
            PlayerPrefs.SetInt("isTutorialPlayed", 0);
            SceneManager.LoadScene(1);
        }
    }
}
