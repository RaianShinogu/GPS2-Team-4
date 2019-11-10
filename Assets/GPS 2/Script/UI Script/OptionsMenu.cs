using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    private bool musicOn = true;
    private bool SFXon = true;

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

    public void setMusicActive()
    {
        musicOn = !musicOn;

        if (musicOn == false)
        {
            Global.audiomanager.setBGMVolume(0.0f);
        }
        else
        {
            Global.audiomanager.setBGMVolume(0.7f);
        }
    }
    public void setSFXActive()
    {
        SFXon = !SFXon;

        if (musicOn == false)
        {
            Global.audiomanager.setSFXVolume(0.0f);
        }
        else
        {
            Global.audiomanager.setSFXVolume(0.7f);
        }
    }
}
