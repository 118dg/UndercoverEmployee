using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScroller : MonoBehaviour
{
    // TODO: 배경 이미지 슬라이드

    public SpriteRenderer[] walls;
    public Sprite[] backGroundImg;
    public float speed;

    FrameProducer frameproducer;

    // Start is called before the first frame update
    void Start()
    {
        temp = walls[0];
        frameproducer = GameObject.Find("MatchManager").GetComponent<FrameProducer>();
    }
    SpriteRenderer temp;

    // Update is called once per frame
    void Update()
    {
        if (!frameproducer.end && !frameproducer.pause)
        {
            for (int i = 0; i < walls.Length; i++)
            {
                if (-15 >= walls[i].transform.position.x)
                {
                    for (int q = 0; q < walls.Length; q++)
                    {
                        if (temp.transform.position.x < walls[q].transform.position.x)
                            temp = walls[q];
                    }
                    walls[i].transform.position = new Vector2(temp.transform.position.x + 3.6f, temp.transform.position.y);
                    walls[i].sprite = backGroundImg[Random.Range(0, backGroundImg.Length)];
                }
            }

            for (int i = 0; i < walls.Length; i++)
            {
                walls[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);
            }
        }
    }
}
