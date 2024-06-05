using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public float speed = 5f; // 플레이어 이동 속도
    public float jumpPower = 5f; // 점프 힘
    private bool isGrounded; // 플레이어가 바닥에 닿아 있는지 확인


    
    public float laserRange = 4f;

    private SpriteRenderer spriteRenderer;

    public TalkManager manager;

    private AudioSource audio;

    BoxCollider2D boxCollider;

    public GameObject targetObject;

    private bool laserHitOnce = false; // 레이저가 충돌했는지 여부


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();



    }




    void Update()
    {
        // 이동
        float moveInput = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // 방향 전환
        if (moveInput > 0)
        {
            spriteRenderer.flipX = false;

        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;

        }



        // 점프 (스페이스바 사용)
       

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !manager.isAction)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }


        ShootLaser();
    }





    // 바닥에 닿았는지 확인
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "sound")
        {
            audio.Play();
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }


    void ShootLaser()
    {
        // 레이저의 방향과 시작 위치를 설정하기
        Vector2 direction = spriteRenderer.flipX ? Vector2.left : Vector2.right;
        Vector2 startPosition = transform.position;

        int layerMask = LayerMask.GetMask("Target");

        //레이저 발사 
        RaycastHit2D hit = Physics2D.Raycast(startPosition, direction, laserRange, layerMask);
        Debug.DrawRay(startPosition, direction * laserRange, Color.red);


        //맞춘 애들 이름 검사
        if (hit.collider != null)
        {
            
            if (Input.GetButtonDown("Jump"))
            {
                manager.Action();
                SetIsTrigger(targetObject); // istrigger 켜기
            }

            if (!laserHitOnce) // 처음으로 맞추었을 때만
            {
                manager.Sus();
                laserHitOnce = true; // 레이저가 맞추었음을 기록
            }

            Debug.Log("히히 맞았다" + hit.collider.gameObject.name);
            

        }

    }

    void SetIsTrigger(GameObject target)
    {
    
        BoxCollider2D boxCollider = target.GetComponent<BoxCollider2D>();
        if (boxCollider != null)
        {
            boxCollider.isTrigger = true;
            Debug.Log("BoxCollider isTrigger set to true for " + target.name);
        }

    }
}

