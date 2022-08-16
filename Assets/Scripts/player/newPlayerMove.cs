using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPlayerMove : MonoBehaviour
{
    public float moveSpeed;
    float hMove;
    public Vector3 movement;
    private Rigidbody rigid;
    public Vector3 velopcityMove;
    public float maxSpeed;

    Vector3 theScale; //�¿������

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (hMove < 0 && transform.localScale.x > 0)
        {
            theScale = transform.localScale;
            theScale.x *= -1;

            transform.localScale = theScale;
        }
        else if (hMove > 0 && transform.localScale.x < 0)
        {
            theScale = transform.localScale;
            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }

    void FixedUpdate()
    {
        GetInput();
        Move();
    }

    private void GetInput()
    {

        hMove = Input.GetAxisRaw("Horizontal");

    }

    public void Move()
    {
        /* ����� ��ǥ�� �����̱�
        movement.Set(hMove, 0, 0);
        movement = movement.normalized * moveSpeed * Time.deltaTime; //������ �� �ӵ� ����

        rigid.MovePosition(transform.position + movement);
        */
        //rigid.velocity = movement; //���� �߰��� ������

        velopcityMove = new Vector3(hMove, 0, 0) * moveSpeed; //velopcity�� ������ ������ ĳ���� �̵�
        //rigid.velocity = velopcityMove* moveSpeed;

        rigid.AddForce(velopcityMove);

        if (rigid.velocity.x > maxSpeed)//������
        {
            rigid.velocity = new Vector3(maxSpeed, rigid.velocity.y, 0);
        }
        else if (rigid.velocity.x < maxSpeed * (-1))//����
        {
            rigid.velocity = new Vector3(maxSpeed*(-1), rigid.velocity.y, 0);
        }

    }
}
