using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linkCode : MonoBehaviour
{
    public void OpenSite()
    {
#if !UNITY_EDITOR
        Application.OpenURL("https://www.instagram.com/pictagamestudio/");
#endif

    }

}
