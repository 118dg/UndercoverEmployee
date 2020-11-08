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

    static public int leftArmIdx;
    static public int rightArmIdx;
    static public int leftLegIdx;
    static public int rightLegIdx;

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
        if (Input.GetKeyDown(KeyCode.A))
        {   //왼팔
            leftArmRend.sprite = LeftArmSprite[(++leftArmIdx) % 3];
            if (leftArmIdx % 3 == 0) //왼팔 아래
            {
                leftArmRend.transform.position = new Vector2(-3.8356f, -1.7318f + 0.42f);
            }
            else if (leftArmIdx % 3 == 1) //왼팔 중간
            {
                leftArmRend.transform.position = new Vector2(-3.8356f - 0.17f, -1.7318f + 0.14f + 0.40f);
            }
            else if (leftArmIdx % 3 == 2) //왼팔 위
            {
                leftArmRend.transform.position = new Vector2(-3.8356f - 0.07f, -1.7318f + 0.33f + 0.40f);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {  //오른팔
            rightArmRend.sprite = rightArmSprite[(++rightArmIdx) % 3];
            if (rightArmIdx % 3 == 0) //오른팔 아래
            {
                rightArmRend.transform.position = new Vector2(-3.305f - 0.03f, -1.713f + 0.44f);
            }
            else if (rightArmIdx % 3 == 1) //오른팔 중간
            {
                rightArmRend.transform.position = new Vector2(-3.8356f + 0.7f, -1.7318f + 0.2f + 0.44f);
            }
            else if (rightArmIdx % 3 == 2) //오른팔 위
            {
                rightArmRend.transform.position = new Vector2(-3.325f, -1.7318f + 0.36f + 0.44f);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {  //왼다리
            leftLegRend.sprite = leftLegSprite[(++leftLegIdx) % 3];
            if (leftLegIdx % 3 == 0) //왼다리 아래
            {
                leftLegRend.transform.position = new Vector2(-3.6864f + 0.01f, -2.258f + 0.44f);
            }
            else if (leftLegIdx % 3 == 1) //왼다리 중간
            {
                leftLegRend.transform.position = new Vector2(-3.6864f - 0.075f, -2.258f + 0.048f + 0.44f);
            }
            else if (leftLegIdx % 3 == 2) //왼다리 위(굽)
            {
                leftLegRend.transform.position = new Vector2(-3.6864f - 0.04f, -2.258f + 0.1f + 0.44f);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {  //오른다리
            rightLegRend.sprite = rightLegSprite[(++rightLegIdx) % 3];
            if (rightLegIdx % 3 == 0) //오른다리 아래
            {
                rightLegRend.transform.position = new Vector2(-3.4055f, -2.2317f + 0.44f);
            }
            else if (rightLegIdx % 3 == 1) //오른다리 중간
            {
                rightLegRend.transform.position = new Vector2(-3.4055f + 0.15f, -2.2317f + 0.048f + 0.44f);
            }
            else if (rightLegIdx % 3 == 2) //오른다리 위(굽)
            {
                rightLegRend.transform.position = new Vector2(-3.4055f + 0.065f, -2.2317f + 0.1f + 0.44f);
            }
        }
    }
}