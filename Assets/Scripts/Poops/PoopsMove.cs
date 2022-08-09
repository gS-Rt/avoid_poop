using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopsMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="wall")
        {
            Destroy(this.gameObject); //충돌하면 해당 오브젝트 삭제
        }
        else if (collision.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }
}
