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

        }
    }

    private void genPoop(float y)
    {
        float x = Random.Range(-4f, 4f);
        
    }
}
