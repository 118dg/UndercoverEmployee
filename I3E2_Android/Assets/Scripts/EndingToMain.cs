using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingToMain : MonoBehaviour
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

        if (Input.GetKeyDown(KeyCode.Mouse0))   // 다시하기 클릭
        { 
            Vector2 mousePos2D = Camera.main.ScreenToWorldPoint(Input.mousePosition);   //마우스 위치 가져오기

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);  
            if (hit.collider != null)
            {
                StartCoroutine("changeScene");
            }

        }

    	if(time <0.5f){
    		GetComponent <SpriteRenderer>().color = new Color(1,1,1,1-time);
    	}else{
    		GetComponent<SpriteRenderer>().color = new Color(1,0,0,time);
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
		SceneManager.LoadScene("StartScene");
    }
}
