using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopGen : MonoBehaviour
{
    public float genTime;
    public float genTimer;
    public GameObject poopPrefab; //¶Ë ÇÁ¸®Æé ¿ÀºêÁ§Æ®
    public float xRandomRange;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        genTimer += Time.deltaTime;
        if (genTimer >= genTime)
        {
            genTimer = 0;
            genPoop(42f);
        }
    }

    private void genPoop(float y)
    {
        xRandomRange = Random.Range(-10f, 10f);
        Instantiate(poopPrefab, new Vector3(xRandomRange, y, 0), Quaternion.identity);


    }
}
