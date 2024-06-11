using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jombie : MonoBehaviour
{
    public float speed = 2f; // 이동 속도
    public int health = 100; // 체력
    public int damage = 10; // 플레이어에게 입히는 데미지
  

    private Transform player; // 플레이어 위치
    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
       

     
    }

    void Update()
    {
        if (player != null)
        {
            // 플레이어를 향해 이동
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = new Vector2(direction.x, direction.y) * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어에게 데미지 입히기
            Player playerScript = other.GetComponent<Player>();
            if (playerScript != null)
            {
                playerScript.TakeDamage(damage);
            }
            // 좀비 제거
            Destroy(gameObject);
        }
        else if (other.CompareTag("Bullet"))
        {
            // 총알에 맞았을 때 데미지 받기
            Bullet bullet = other.GetComponent<Bullet>();
            if (bullet != null)
            {
                TakeDamage(bullet.damage);
            }
            Destroy(other.gameObject); // 총알 제거
        }
    }

    // 좀비가 데미지를 받는 메서드
    void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            // 좀비 체력이 0 이하일 때 카운트를 증가시키고 좀비 제거
           // Player playerpo= GetComponent<Player>();
           //playerpo.count += 1;
            Destroy(gameObject);
        }
    }
}

