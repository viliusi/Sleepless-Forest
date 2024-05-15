using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Boullet : MonoBehaviour
{
    //link "bulletDamage" and EnemyStats to weapon.cs
    public EnemyStats enemyStats;
    public PlayerStats playerStats;
    public BossPhase bossPhase;
    public GameObject Weapon;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("PlayerTag");
        playerStats = player.GetComponent<PlayerStats>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyTag")
        {
            Weapon weapon = Weapon.GetComponent<Weapon>();
            float damage = weapon.bulletDamage * (1 + playerStats.damageMultiplier);
            EnemyStats enemystats = collision.gameObject.GetComponent<EnemyStats>();
            enemystats.health -= damage;
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag != "PlayerTag")
        {
            Destroy(gameObject);
        }
    }
}
