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
            Weapon script = Weapon.GetComponent<Weapon>();
            int damage = script.bulletDamage;
            enemyStats.TakeDamage(damage);
        }
        else if (collision.gameObject.tag != "PlayerTag")
        {
            Destroy(gameObject);
        }
    }
}
