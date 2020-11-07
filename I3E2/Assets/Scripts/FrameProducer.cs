using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class FrameProducer : MonoBehaviour
{
    public GameObject[] frames;
    // public Sprite[] groundImg;

    public Sprite[] LAImg = new Sprite[3];
    public Sprite[] RAImg = new Sprite[3];
    public Sprite[] LLImg = new Sprite[3];
    public Sprite[] RLImg = new Sprite[3];

    public int[] LAIdx = new int [7];
    public int[] RAIdx = new int [7];
    public int[] LLIdx = new int [7];
    public int[] RLIdx = new int [7];

    public float speed;

    GameObject temp;

    public int level = 0;   // 0 -> 5 matches(10), 1 -> 5 ~ 20 matches(7), 2 -> 20 ~~ matches(4);
    public int matches = 0;


    // Start is called before the first frame update
    void Start()
    {
        temp = frames[0];
        for(int i=0;i<frames.Length; i++){
            
            LAIdx[i] = Random.Range(0, LAImg.Length);
            RAIdx[i] = Random.Range(0, LAImg.Length);
            LLIdx[i] = Random.Range(0, LAImg.Length);
            RLIdx[i] = Random.Range(0, LAImg.Length);

            frames[i].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = LAImg[LAIdx[i]];
            frames[i].transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = LLImg[LLIdx[i]];
            frames[i].transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite = RAImg[RAIdx[i]];
            frames[i].transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().sprite = RLImg[RLIdx[i]];

            if(i!=0){
                frames[i].transform.position = new Vector2(temp.transform.position.x + 10, temp.transform.position.y);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i < frames.Length; i++)
        {

            if(-10 >= frames[i].transform.position.x)
            {
                for(int q = 0; q <frames.Length; q++)
                {
                    if (temp.transform.position.x < frames[q].transform.position.x)
                        temp = frames[q];
                }
                if(level == 0){   // level에 따라서 등장 간격
                    frames[i].transform.position = new Vector2(temp.transform.position.x + 10, temp.transform.position.y);
                }else if(level == 1){
                    frames[i].transform.position = new Vector2(temp.transform.position.x + 7, temp.transform.position.y);
                }else if(level == 2){
                    frames[i].transform.position = new Vector2(temp.transform.position.x + 4, temp.transform.position.y);
                }

                LAIdx[i] = Random.Range(0, LAImg.Length);
                RAIdx[i] = Random.Range(0, LAImg.Length);
                LLIdx[i] = Random.Range(0, LAImg.Length);
                RLIdx[i] = Random.Range(0, LAImg.Length);

                frames[i].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = LAImg[LAIdx[i]];
                frames[i].transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = LLImg[LLIdx[i]];
                frames[i].transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite = RAImg[RAIdx[i]];
                frames[i].transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().sprite = RLImg[RLIdx[i]];
            }
            else if(frames[i].transform.position.x + 1.38 == -3.61){
                //체크! 네개 다 같으면 점수 ++
                //블록 이미지 불빛 변경
                //틀리면 블록 이미지 배경 빨강색, 불빛도 빨강색
                if(LAIdx[i] == UserMotion.leftArmIdx){
                    
                }

            }
        }

        for(int i=0; i<frames.Length; i++)
        {
            frames[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);
        }
    }
}
