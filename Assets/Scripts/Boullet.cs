using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boullet : MonoBehaviour
{
    //link "bulletDamage" and EnemyStats to weapon.cs
    public EnemyStats enemyStats;

  void OnCollisionEnter2D(Collision2D collision)
  {
        if (collision.gameObject.tag != "EnemyTag")
        {
            enemyStats.TakeDamage(Weapon.bulletDamage);
        }
  }
}
