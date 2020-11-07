using System;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class FrameProducer : MonoBehaviour
{


    private AudioSource mainTheme;
    public AudioClip mainSound;

    public Text moneytext;
    public GameObject[] frames;
    public GameObject character;

    public Sprite[] LAImg = new Sprite[3];
    public Sprite[] RAImg = new Sprite[3];
    public Sprite[] LLImg = new Sprite[3];
    public Sprite[] RLImg = new Sprite[3];

    public Sprite failBG;

    public int[] LAIdx = new int [7];
    public int[] RAIdx = new int [7];
    public int[] LLIdx = new int [7];
    public int[] RLIdx = new int [7];

    public bool[] flags = new bool[7];

    public float speed;

    GameObject temp;

    public int level = 0;   // 0 -> 5 matches(10), 1 -> 5 ~ 20 matches(7), 2 -> 20 ~~ matches(4);
    public int matches = 0;
    public int money;


    public GameObject Ending;
    public Sprite[] EndingImg = new Sprite[3];
    public bool end = false;
    public Text endingText;


    // Start is called before the first frame update
    void Start()
    {   
        this.mainTheme = this.gameObject.AddComponent<AudioSource>();
        this.mainTheme.clip = this.mainSound;
        this.mainTheme.loop = true;
        this.mainTheme.Play();

        Ending.SetActive(false);
        end = false;

        temp = frames[0];
        money = 1800;
        moneytext.text = String.Format("{0:C}", money) + " 만원";

        for (int i=0;i<frames.Length; i++){
            flags[i] = false;
            
            LAIdx[i] = UnityEngine.Random.Range(0, LAImg.Length);
            RAIdx[i] = UnityEngine.Random.Range(0, LAImg.Length);
            LLIdx[i] = UnityEngine.Random.Range(0, LAImg.Length);
            RLIdx[i] = UnityEngine.Random.Range(0, LAImg.Length);

            frames[i].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = LAImg[LAIdx[i]];
            frames[i].transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = LLImg[LLIdx[i]];
            frames[i].transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite = RAImg[RAIdx[i]];
            frames[i].transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().sprite = RLImg[RLIdx[i]];

            if(i!=0){
                frames[i].transform.position = new Vector2(frames[i-1].transform.position.x + 10, temp.transform.position.y);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!end){
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

                    flags[i] = false;
                    frames[i].transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1 ,1);

                    LAIdx[i] = UnityEngine.Random.Range(0, LAImg.Length);
                    RAIdx[i] = UnityEngine.Random.Range(0, LAImg.Length);
                    LLIdx[i] = UnityEngine.Random.Range(0, LAImg.Length);
                    RLIdx[i] = UnityEngine.Random.Range(0, LAImg.Length);

                    frames[i].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = LAImg[LAIdx[i]];
                    frames[i].transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = LLImg[LLIdx[i]];
                    frames[i].transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite = RAImg[RAIdx[i]];
                    frames[i].transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().sprite = RLImg[RLIdx[i]];
                }
                else if(frames[i].transform.position.x < character.transform.position.x -0.3f&& frames[i].transform.position.x >= character.transform.position.x-0.7f)
                {

                    if(LAIdx[i] == UserMotion.leftArmIdx%3 && RAIdx[i] == UserMotion.rightArmIdx % 3 && LLIdx[i] == UserMotion.leftLegIdx % 3 && RLIdx[i] == UserMotion.rightLegIdx % 3)
                    {
                        if(flags[i] == false)
                        {
                            matches += 1;
                            money += 100;
                            moneytext.text = String.Format("{0:C}", money)+" 만원";
                            frames[i].transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
                            
                            if(matches>=3 && matches < 12)
                            {
                                level = 1;
                            }else if(matches >= 12)
                            {
                                level = 2;
                            }

                        }
                        flags[i] = true;
                    }
                    else
                    {   
                        frames[i].transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
                        frames[i].transform.GetChild(6).gameObject.GetComponent<SpriteRenderer>().sprite = failBG;

                        showEnding();
                    }

                }
            }

            for(int i=0; i<frames.Length; i++)
            {
                frames[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);
            }
        }
    }

    public void showEnding(){
        this.mainTheme.Stop();
        Ending.SetActive(true);
        end = true;

        int textChoice = UnityEngine.Random.Range(0, 2);

        //TODO: 이거 글자 뭔가 깨짐

        if(money < 3400){
            Ending.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = EndingImg[0];
            if(textChoice == 0){
                endingText.text = "왹들도 이직을 노린다. \n"+"연봉 "+money+"만원의 중소기업 취업!";
            }else{
                endingText.text = "열심히 노력했지만 지구는 녹록치 않았다. \n"+"연봉 "+money+"만원의 중소기업 취업!";
            }
        }else if(3400<=money && money<8000){
            Ending.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = EndingImg[1];
            if(textChoice == 0){
                endingText.text = "왹들도 스펙쌓기는 효과를 보장했다. \n"+"연봉 "+money+"만원의 대기업 취업!";
            }else{
                endingText.text = "시기를 잘 탔다. \n"+"연봉 "+money+"만원의 대기업 취업!";
            }
        }else{
            Ending.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = EndingImg[2];
            if(textChoice == 0){
                endingText.text = "운도 실력이다. \n"+"연봉 "+money+"만원의 여우로운 왹생!";
            }else{
                endingText.text = "돈길을 걷다보니 하와이에 도착했다. \n"+"흘러넘치는 재산의 왹생!";
            }
        }
    }
}
