﻿using UnityEngine;

using System;

public class AudioManager : MonoBehaviour {

    [SerializeField] private Audio[] sfx;
    [SerializeField] private Audio[] bgm;

    private float masterVolume = 0.7f;

    public void Awake() {

        if (Global.audiomanager == null) { Global.audiomanager = this; }
        else { Destroy(gameObject); return; }


        DontDestroyOnLoad(gameObject);

        for(int i = 0; i < sfx.Length; i++) {

            sfx[i].init(gameObject.AddComponent<AudioSource>(), masterVolume);

        }

        for (int i = 0; i < bgm.Length; i++) {

            bgm[i].init(gameObject.AddComponent<AudioSource>(), masterVolume);

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
                //Debug.Log("play");
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

}
