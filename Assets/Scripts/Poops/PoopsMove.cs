using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopsMove : MonoBehaviour
{

    private int isPutOn;
    public GameObject player;
    public Vector3 playerMovement;

    void Start()
    {
        isPutOn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        /*
        if(isPutOn>1)
        {
            playerMovement=player.GetComponent<newPlayerMove>().movement;
            this.gameObject.GetComponent<Rigidbody>().MovePosition(transform.position + playerMovement);
        }
        */
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="wall")
        {
            Destroy(this.gameObject); //충돌하면 해당 오브젝트 삭제
        }
        else if (collision.gameObject.tag == "Player")
        {
            isPutOn += 1;
            //this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            //this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(50, 0, 0);
        }
    }
}
