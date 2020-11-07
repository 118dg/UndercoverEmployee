using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

	// TODO: 레벨 따라서 속도 조절 
	public static SoundManager instance;

	public AudioClip[] ThemeMusic = new AudioClip[3];
	AudioSource myAudio;

   	private void Awake(){
   		if(SoundManager.instance == null){
   			SoundManager.instance = this;
   		}
   	}

   	void Start(){
   		myAudio = GetComponent<AudioSource>();
   	}

    void BGMManager(int level){
    	myAudio.clip = ThemeMusic[level];
    	myAudio.Play();
    }
}
