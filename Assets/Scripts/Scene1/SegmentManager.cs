using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentManager : MonoBehaviour
{
    public GameObject s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, copy,boostT,boostJ,boostR;
    public int chosen,counter,BLX,BLY;
    public float k = 27;
    void Start()
    {
        StartCoroutine(spawner());
        BLX = Random.Range(12, 19);
        BLY = Random.Range(32, 151);
        boostT.transform.position = new Vector3(BLX, BLY, 0);
        BLX = Random.Range(12, 19);
        BLY = Random.Range(32, 151);
        boostJ.transform.position = new Vector3(BLX, BLY, 0);
        BLX = Random.Range(12, 19);
        BLY = Random.Range(32, 151);
        boostR.transform.position = new Vector3(BLX, BLY, 0);
    }

    void Update()
    {
        
    }
    IEnumerator spawner()
    {
        while (counter<15)
        {
            chosen = Random.Range(0, 10);
            switch (chosen)
            {
                case 1:
                    copy = Instantiate(s1);
                    copy.SetActive(true);
                    break;
                case 2:
                    copy = Instantiate(s2);
                    copy.SetActive(true);
                    break;
                case 3:
                    copy = Instantiate(s3);
                    copy.SetActive(true);
                    break;
                case 4:
                    copy = Instantiate(s4);
                    copy.SetActive(true);
                    break;
                case 5:
                    copy = Instantiate(s5);
                    copy.SetActive(true);
                    break;
                case 6:
                    copy = Instantiate(s6);
                    copy.SetActive(true);
                    break;
                case 7:
                    copy = Instantiate(s7);
                    copy.SetActive(true);
                    break;
                case 8:
                    copy = Instantiate(s8);
                    copy.SetActive(true);
                    break;
                case 9:
                    copy = Instantiate(s9);
                    copy.SetActive(true);
                    break;
                case 0:
                    copy = Instantiate(s10);
                    copy.SetActive(true);
                    break;
            }
            copy.transform.position = new Vector3(15f, k, 72f);
            k = k + 10f;
            counter++;
            yield return null;
        }
    }
    
}
