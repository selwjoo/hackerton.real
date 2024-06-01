using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public float speed = 5f; // 플레이어 이동 속도
    public float jumpPower = 5f; // 점프 힘
    private bool isGrounded; // 플레이어가 바닥에 닿아 있는지 확인

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    public void Move()
    {
        // 입력값 받아오기
        float moveHorizontal = Input.GetAxis("Horizontal"); // A와 D 또는 화살표 좌우

        // 이동 방향 설정
        Vector2 movement = new Vector2(moveHorizontal * speed, rb.velocity.y);

        // 이동
        rb.velocity = movement;
    }

    public void Jump()
    {
        // 점프 입력 감지 및 바닥에 닿아있는지 확인
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }
    }

    // 바닥에 닿았는지 확인
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

