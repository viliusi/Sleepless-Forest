using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Transform Player;

    public float BulletForce = 20f;
    public int bulletDamage;
    public EnemyStats enemyStats;

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.position;

        if (Input.GetButtonDown("Fire1"))
        {
            Shooting();
        }
    }

    void Shooting()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * BulletForce, ForceMode2D.Impulse);
    }
}
