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
            Destroy(this.gameObject); //�浹�ϸ� �ش� ������Ʈ ����
        }
        else if (collision.gameObject.tag == "Player")
        {
            isPutOn += 1;
            //this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            //this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(50, 0, 0);

            poopStack = 1; //�÷��̾� �Ӹ� ���� �������� 1�� ��
        }
        else if (collision.gameObject.tag == "poop" && poopStack == 0) //���� ���� �浹���� �ʾ��� ���� 1ȸ ����
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

    private void OnCollisionStay(Collision collision) //1�� ���� ���� �ڵ�
    {
        if(collision.gameObject.GetComponent<PoopsMove>().isBreak==true) //2�� ���� �ı������� ���� �Ǹ� ���� �ı�
        {
            Destroy(this.gameObject);
        }
    }

    /*
     * ����� 3�� ������ �� �ı�
     * �׷��� ��ž�� ��� �״ٰ� Ư�� ��ȣ�ۿ��� �ϸ� ���� �����鼭 ���ʽ� ���� ������ �ص� ������
     * ������ �������� ���� ������ ��� �����⿣ ����ũ�� Ŀ�� ���� ������
     */

}
