using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class likndeux : MonoBehaviour
{

    public void OpenSiteYoutube()
    {
#if !UNITY_EDITOR
                Application.OpenURL("https://www.youtube.com/channel/UCalwL1JaZaOYowPiX5mAJAA?guided_help_flow=3");

#endif

    }

}
