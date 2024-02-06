using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public EnemyShooting EnemyShooting;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerTag")
        {
            /*Weapon weapon = Weapon.GetComponent<Weapon>();
            int damage = (weapon.bulletDamage);
            EnemyStats enemystats = collision.gameObject.GetComponent<EnemyStats>();
            enemystats.health -= damage;
            Destroy(gameObject);*/
        }
    }
    }
