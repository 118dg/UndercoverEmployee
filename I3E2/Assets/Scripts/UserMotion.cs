using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMotion : MonoBehaviour
{
	public GameObject leftArm;
	public GameObject rightArm;
	public GameObject leftLeg;
	public GameObject rightLeg;

	public SpriteRenderer leftArmRend;
	public SpriteRenderer rightArmRend;
	public SpriteRenderer leftLegRend;
	public SpriteRenderer rightLegRend;

	public Sprite[] LeftArmSprite = new Sprite[3];
	public Sprite[] rightArmSprite = new Sprite[3];
	public Sprite[] leftLegSprite = new Sprite[3];
	public Sprite[] rightLegSprite = new Sprite[3];

	public int leftArmIdx;
	public int rightArmIdx;
	public int leftLegIdx;
	public int rightLegIdx;
	
    // Start is called before the first frame update
    void Start()
    {
    	leftArmIdx = 0;
    	rightArmIdx = 0;
    	leftLegIdx = 0;
    	rightArmIdx = 0;

    	leftArmRend = leftArm.GetComponent<SpriteRenderer>();
    	rightArmRend = rightArm.GetComponent<SpriteRenderer>();
    	leftLegRend = leftLeg.GetComponent<SpriteRenderer>();
    	rightLegRend = rightLeg.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){   //왼팔
        	leftArmRend.sprite = LeftArmSprite[(leftArmIdx++)%3];
        }
        if(Input.GetKeyDown(KeyCode.D)){  //오른팔
        	rightArmRend.sprite = rightArmSprite[(rightArmIdx++)%3];
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)){  //왼다리
        	leftLegRend.sprite = leftLegSprite[(leftLegIdx++)%3];        	
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){  //오른다리
        	rightLegRend.sprite = rightLegSprite[(rightLegIdx++)%3];
        }
    }
}
