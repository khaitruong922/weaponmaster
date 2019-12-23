﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fogOfWar;
    public GameObject[] player;
    public GameObject[] UI;
    public GameObject defeatScreen;
    public GameObject winScreen;
    public static GameHandler Instance {get;set;}
    bool oneTimeCall = false;
    public int mapNumber = 0;
    public AudioClip clip;

    void Awake() {
        if(AudioManager.Instance != null && AudioManager.Instance.sounds[0].clip != clip){
            AudioManager.Instance.ChangeAudio(clip,true);
        }
        Instance = this;
        defeatScreen.SetActive(false);
        winScreen.SetActive(false);
        Time.timeScale =1;
        fogOfWar.SetActive(true);
        Instantiate(player[PlayerPrefs.GetInt("CharNumber",0)],transform.position,transform.rotation);
        Instantiate(UI[PlayerPrefs.GetInt("CharNumber",0)],transform.position,Quaternion.identity);
        Debug.Log("Character "+PlayerPrefs.GetInt("CharNumber",0)+" selected");
    }
    public void Win(){
        winScreen.SetActive(true);
        StartCoroutine(DelayStop(1));
        if (PersistentData.Instance != null && oneTimeCall == false){
        oneTimeCall = !oneTimeCall; // call function once
        PersistentData.Instance.level +=1 ;
        }
    }
    public void Defeat(){
        defeatScreen.SetActive(true);
        StartCoroutine(DelayStop(1));
        if (PersistentData.Instance != null && oneTimeCall == false){
        oneTimeCall = !oneTimeCall; // call function once
        }
    }
    IEnumerator DelayStop(float seconds){
        yield return new WaitForSeconds(seconds);
        Time.timeScale=0f;
    }
    }
