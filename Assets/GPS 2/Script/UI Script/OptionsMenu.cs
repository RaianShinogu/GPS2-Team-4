using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
  public void SetMasterVolume(float volume)
    {
        Global.audiomanager.setMasterVolume(volume);

    }
    public void SetBGMvolume(float volume)
    {
        Global.audiomanager.setBGMVolume(volume);

    }
    public void SetSFXvolume(float volume)
    {
        Global.audiomanager.setSFXVolume(volume);

    }
}
