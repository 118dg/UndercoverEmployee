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

	public GameObject guide;
	private AudioSource effect;
	public AudioClip guideSound;

	void Start(){

		guide.SetActive(false);
		
		this.soundTrack = this.gameObject.AddComponent<AudioSource>();
		this.soundTrack.clip = this.startSound;
		this.soundTrack.loop = true;
		this.soundTrack.Play();

		this.btnClick = this.gameObject.AddComponent<AudioSource>();
		this.btnClick.clip = this.btnSound;
		this.btnClick.loop = false;

		this.effect = this.gameObject.AddComponent<AudioSource>();
		this.effect.clip = this.guideSound;
		this.effect.loop = false;
	}
    // Update is called once per frame
    void Update()
    {
		if(Input.GetKeyDown(KeyCode.Tab)){
			if(!guide.active){
				effect.Play();
				guide.SetActive(true);
			}else{
				guide.SetActive(true);
			}

    	}else if(Input.GetKeyUp(KeyCode.Tab)){
			guide.SetActive(false);
    	}
    	else{
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
