using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPlayerMove : MonoBehaviour
{
    public float moveSpeed;
    float hMove;
    public Vector3 movement;
    private Rigidbody rigid;

    Vector3 theScale; //좌우반전용

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

        movement.Set(hMove, 0, 0);
        movement = movement.normalized * moveSpeed * Time.deltaTime; //점프할 땐 속도 변경

        rigid.MovePosition(transform.position + movement);

        //rigid.velocity = movement; //벡터 추가로 움직임


    }
}
