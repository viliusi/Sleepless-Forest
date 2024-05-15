using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float BulletForce = 20f;
    public int bulletDamage;
    public PlayerStats playerStats;
    bool shootingCooldown;
    bool s2Cooldown;
    bool burst;
    public float shootingCooldownDuration;
    public float s2CooldownDuration;
    public float burstDuration;

    public Enemy enemy;

    // Start is called before the first frame update
    private void Start()
    {
        shootingCooldown = false;
        s2Cooldown = false;
        burst = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.IsActive == true)
        {
            // enemy shooting function
            if (shootingCooldown == false)
            {


                        shootingCooldown = true;

                        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                        EnemyBullet script = bullet.GetComponent<EnemyBullet>();

                        script.BossShooting = this;
                        print("shooting");

                        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                        rb.AddForce(firePoint.up * BulletForce, ForceMode2D.Impulse);
                        print("Enemy" + firePoint.up);
                        StartCoroutine(ShootingCooldown());


            }

            // Boss burstfire function
            if (burst == false)
            {
                burst = true;
                StartCoroutine(Burst());

                if (s2Cooldown == false)
                {


                    s2Cooldown = true;

                    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                    EnemyBullet script = bullet.GetComponent<EnemyBullet>();

                    script.BossShooting = this;
                    print("shooting");

                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.AddForce(firePoint.up * BulletForce, ForceMode2D.Impulse);
                    print("Enemy" + firePoint.up);
                    StartCoroutine(S2Cooldown());


                }
            }


        }


    }

    // cooldown timers
    private IEnumerator ShootingCooldown()
    {
        shootingCooldown = true;
        yield return new WaitForSeconds(shootingCooldownDuration);
        shootingCooldown = false;
    }

    private IEnumerator Burst()
    {
        burst = true;
        yield return new WaitForSeconds(burstDuration);
        burst = false;
    }

    private IEnumerator S2Cooldown()
    {
        s2Cooldown = true;
        yield return new WaitForSeconds(s2CooldownDuration);
        s2Cooldown = false;
    }
}
