using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public Transform Player;
    public EnemyStats enemyStats;
    public GameObject MeleeWeapon;

    private int meleeDamage;

    void Update()
    {
        transform.position = Player.position;
        
        if (Input.GetButtonDown("Fire2"))
        {
            Hitting();
        }
    }

    void Hitting()
    {
        
    }

    private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
            Melee meleeweapon = MeleeWeapon.GetComponent<Melee>();
            int damage = (meleeweapon.meleeDamage);
            EnemyStats enemystats = other.gameObject.GetComponent<EnemyStats>();
            enemystats.health -= damage;
            }
        }
    }

