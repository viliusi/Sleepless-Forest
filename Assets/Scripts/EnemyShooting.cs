using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float BulletForce = 20f;
    public int bulletDamage;
    public PlayerStats playerStats;
    bool shootingCooldown;
    public float shootingCooldownDuration = 0.5f;

    public Enemy enemy;

    public BossPhase bossPhase;

    private void Start()
    {
        shootingCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.IsActive == true)
        {

        if (shootingCooldown == false)
        {
            shootingCooldown = true;    
                
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            EnemyBullet script = bullet.GetComponent<EnemyBullet>();

            script.EnemyShooting = this;
            print("shooting");

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce( firePoint.up * BulletForce, ForceMode2D.Impulse);
            print("Enemy" + firePoint.up);
            StartCoroutine(ShootingCooldown());
        }
        }
    }

    private IEnumerator ShootingCooldown()
    {
        shootingCooldown = true;
        yield return new WaitForSeconds(shootingCooldownDuration);
        shootingCooldown = false;


    }
}
