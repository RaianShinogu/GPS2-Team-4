using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour {

    public AudioMixer audiomixer;

    [SerializeField] private Audio[] sfx;
    [SerializeField] private Audio[] bgm;

    private float masterVolume = 0.7f;
    private float putSFXvolume = 0.7f;
    private float putBGMvolume = 0.7f;
    public bool SFXon = true;
    public bool BGMon = true;

    public void Awake() {

        if (Global.audiomanager == null) { Global.audiomanager = this; }
        else { Destroy(gameObject); return; }


        DontDestroyOnLoad(gameObject);

        for(int i = 0; i < sfx.Length; i++) {

            sfx[i].init(gameObject.AddComponent<AudioSource>(), putSFXvolume);

        }

        for (int i = 0; i < bgm.Length; i++) {

            bgm[i].init(gameObject.AddComponent<AudioSource>(), putBGMvolume);

        }

    }

    public void stopAllSFX() {

        for(int i = 0; i < sfx.Length; i++) {

            sfx[i].stop();

        }

    }

    public void stopAllBGM() {

        for (int i = 0; i < sfx.Length; i++) {

            bgm[i].stop();

        }

    }

    public Audio getSFX(string name) {

        int counter = 0;

        for ( ; counter < sfx.Length; counter++) {

            if (sfx[counter].getName() == name) {
                break;
            }

        }

        if (counter == sfx.Length) {
            Debug.LogWarning("sfx: " + name + " not found!");
            return null;
        }

        return sfx[counter];

    }

    public Audio getBGM(String name) {

        int counter = 0;

        for ( ; counter < bgm.Length; counter++) {

            if (bgm[counter].getName() == name) {

                break;
            }

        }

        if (counter == bgm.Length) {
            Debug.LogWarning("bgm: " + name + " not found!");
            return null;
        }

        return bgm[counter];

    }

    public void setMasterVolume(float masterVolume) {

        this.masterVolume = masterVolume;

        for (int i = 0; i < sfx.Length; i++) {

            sfx[i].setVolume(masterVolume);

        }

        for (int i = 0; i < bgm.Length; i++) {

            bgm[i].setVolume(masterVolume);

        }

    }
    public void setBGMVolume(float BGMVolume)
    {
        //audiomixer.SetFloat("BGMVolume", BGMVolume);

        for (int i = 0; i < bgm.Length; i++)
        {

            bgm[i].setVolume(BGMVolume);
          
        }
        if (BGMVolume == 0.0f)
        {
            BGMon = false;
        }
        else
        {
            BGMon = true;
        }
    }

    public void setSFXVolume(float SFXVolume)
    {

       // audiomixer.SetFloat("SFXVolume", SFXVolume);
        for (int i = 0; i < sfx.Length; i++)
        {

            sfx[i].setVolume(SFXVolume);

            
        }
        if (SFXVolume == 0.0f)
        {
            SFXon = false;
        }
        else
        {
            SFXon = true;
        }
    }

    }
