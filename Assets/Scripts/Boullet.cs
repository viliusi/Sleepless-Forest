using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Boullet : MonoBehaviour
{
    //link "bulletDamage" and EnemyStats to weapon.cs
    public EnemyStats enemyStats;
    public GameObject Weapon;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyTag")
        {
            Weapon weapon = Weapon.GetComponent<Weapon>();
            int damage = (weapon.bulletDamage);
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
