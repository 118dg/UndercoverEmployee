using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public List<GameObject> MobPool = new List<GameObject>();
    public GameObject[] Mobs;
    public int objCnt = 1;

    private void Awake()
    {
        for(int i=0; i<Mobs.Length; i++)
        {
            for(int j=0; j<objCnt; j++)
            {
                MobPool.Add(CreateObj(Mobs[i], transform));
            }
        }
    }

    GameObject CreateObj(GameObject obj, Transform parent)
    {
        GameObject copy = Instantiate(obj);
        copy.transform.SetParent(parent);
        copy.SetActive(false);
        return copy;
    }
}