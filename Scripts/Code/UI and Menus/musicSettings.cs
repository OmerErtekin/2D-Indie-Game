using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class musicSettings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixer audioMixerTwo;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        //Debug.Log(volume);
    }

    public void SetVolumeTwo(float volume)
    {
        audioMixerTwo.SetFloat("volumeTwo", volume);
        //Debug.Log(volume);
    }
}
