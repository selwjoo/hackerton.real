using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPoint;
    public float shootingCooltime;
    bool allowShooting = true;

    public SpriteRenderer spriteRenderer;
    public Vector2 newPivot;

    void Start()
    {
        ChangePivot(spriteRenderer, newPivot);
    }

    void Update()
    { 
        Rotate();
        Shoot();
    }

    void ChangePivot(SpriteRenderer sr, Vector2 newPivot)
    {
        if (sr.sprite == null) return;

        Rect rect = sr.sprite.rect;
        Vector2 originalPivot = sr.sprite.pivot;
        Vector2 newPivotPosition = new Vector2(newPivot.x * rect.width, newPivot.y * rect.height);

        sr.sprite = Sprite.Create(sr.sprite.texture, rect, newPivot, sr.sprite.pixelsPerUnit, 0, SpriteMeshType.Tight, sr.sprite.border);
    }

    void Rotate()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float dx = mousePos.x - transform.position.x;
        float dy = mousePos.y - transform.position.y;

        float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Shoot()
    {
        if (allowShooting && Input.GetMouseButton(0))
        {
            GameObject newBullet = Instantiate(bullet, shotPoint.position, transform.rotation * Quaternion.Euler(0, 0, -90));
            newBullet.GetComponent<Rigidbody2D>().AddForce(newBullet.transform.up * 1000);
            allowShooting = false;
            Invoke("EnableShooting", shootingCooltime);
        }
    }

    void EnableShooting()
    {
        allowShooting = true;
    }
}