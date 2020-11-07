using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextBlink : MonoBehaviour
{
	float time;

	private AudioSource soundTrack;
	public AudioClip startSound;

	private AudioSource btnClick;
	public AudioClip btnSound;

	void Start(){
		this.soundTrack = this.gameObject.AddComponent<AudioSource>();
		this.soundTrack.clip = this.startSound;
		this.soundTrack.loop = true;
		this.soundTrack.Play();

		this.btnClick = this.gameObject.AddComponent<AudioSource>();
		this.btnClick.clip = this.btnSound;
		this.btnClick.loop = false;
	}
    // Update is called once per frame
    void Update()
    {

    	if(Input.GetKeyDown(KeyCode.Space)){
    		StartCoroutine("changeScene");
    	}

    	if(time <0.5f){
    		GetComponent <SpriteRenderer>().color = new Color(1,1,1,1-time);
    	}else{
    		GetComponent<SpriteRenderer>().color = new Color(1,1,1,time);
    		if(time >1f){
    			time = 0;
    		}
    	}
    	time += Time.deltaTime;
    }

    IEnumerator changeScene(){
    	btnClick.Play();
    	while(true){
    		yield return new WaitForSeconds(1.0f);
    		if(!btnClick.isPlaying){
    			break;
    		}
    	}
		SceneManager.LoadScene("MainScene");
    }
}
