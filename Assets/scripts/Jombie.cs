using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jombie : MonoBehaviour
{
    public float speed = 2f; // �̵� �ӵ�
    public int health = 100; // ü��
    public int damage = 10; // �÷��̾�� ������ ������
  

    private Transform player; // �÷��̾� ��ġ
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
            // �÷��̾ ���� �̵�
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = new Vector2(direction.x, direction.y) * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // �÷��̾�� ������ ������
            Player playerScript = other.GetComponent<Player>();
            if (playerScript != null)
            {
                playerScript.TakeDamage(damage);
            }
            // ���� ����
            Destroy(gameObject);
        }
        else if (other.CompareTag("Bullet"))
        {
            // �Ѿ˿� �¾��� �� ������ �ޱ�
            Bullet bullet = other.GetComponent<Bullet>();
            if (bullet != null)
            {
                TakeDamage(bullet.damage);
            }
            Destroy(other.gameObject); // �Ѿ� ����
        }
    }

    // ���� �������� �޴� �޼���
    void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            // ���� ü���� 0 ������ �� ī��Ʈ�� ������Ű�� ���� ����
           // Player playerpo= GetComponent<Player>();
           //playerpo.count += 1;
            Destroy(gameObject);
        }
    }
}

