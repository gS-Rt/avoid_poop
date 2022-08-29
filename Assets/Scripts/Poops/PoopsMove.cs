using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopsMove : MonoBehaviour
{

    private int isPutOn;
    public GameObject player;
    public Vector3 playerMovement;
    public int poopStack;
    private bool isBreak;

    void Start()
    {
        isPutOn = 0;
        poopStack = 0;
        isBreak = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isBreak==true)
        {
            Destroy(this.gameObject);
        }
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
        if (collision.gameObject.tag=="wall")
        {
            Destroy(this.gameObject); //충돌하면 해당 오브젝트 삭제
        }
        else if (collision.gameObject.tag == "Player")
        {
            isPutOn += 1;
            //this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            //this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(50, 0, 0);

            poopStack = 1; //플레이어 머리 위에 떨어지면 1층 똥
        }
        else if (collision.gameObject.tag == "poop" && poopStack == 0) //똥이 아직 충돌되지 않았을 때만 1회 실행
        {
            if (collision.gameObject.GetComponent<PoopsMove>().poopStack == 1)
            {
                poopStack = 2;
            }
            else if (collision.gameObject.GetComponent<PoopsMove>().poopStack == 2)
            {
                isBreak = true;
                collision.gameObject.GetComponent<PoopsMove>().isBreak = true;
            }
        }

    }

    private void OnCollisionStay(Collision collision) //1층 똥을 위한 코드
    {
        if(collision.gameObject.GetComponent<PoopsMove>().isBreak==true) //2층 똥의 파괴변수가 참이 되면 같이 파괴
        {
            Destroy(this.gameObject);
        }
    }

    /*
     * 현재는 3개 쌓으면 똥 파괴
     * 그런데 똥탑을 계속 쌓다가 특정 상호작용을 하면 전부 터지면서 보너스 점수 들어가도록 해도 좋을듯
     * 어차피 게이지의 감소 때문에 계속 모으기엔 리스크가 커질 수도 있을듯
     */

}
