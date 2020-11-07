using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

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
