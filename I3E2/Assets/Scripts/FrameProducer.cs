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

    public int level = 0;   // 0 -> 10 matches, 1 -> 10 ~ 20 matches, 2 -> 20 ~ 30 matches;
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i < frames.Length; i++)
        {
            if(-5 >= frames[i].transform.position.x)
            {
                for(int q = 0; q <frames.Length; q++)
                {
                    if (temp.transform.position.x < frames[q].transform.position.x)
                        temp = frames[q];
                }

                frames[i].transform.position = new Vector2(temp.transform.position.x + 5, temp.transform.position.y);

                LAIdx[i] = Random.Range(0, LAImg.Length);
                RAIdx[i] = Random.Range(0, LAImg.Length);
                LLIdx[i] = Random.Range(0, LAImg.Length);
                RLIdx[i] = Random.Range(0, LAImg.Length);

                frames[i].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = LAImg[LAIdx[i]];
                frames[i].transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = LLImg[LLIdx[i]];
                frames[i].transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite = RAImg[RAIdx[i]];
                frames[i].transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().sprite = RLImg[RLIdx[i]];

                // frames[i].sprite = groundImg[Random.Range(0, groundImg.Length)];
            }
        }

        for(int i=0; i<frames.Length; i++)
        {
            frames[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);
        }
    }
}
