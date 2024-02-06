using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public EnemyShooting EnemyShooting;

    // Start is called before the first frame update
    void Start()
    {
        print("Created Bullet");   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerTag")
        {
            GameObject player = collision.gameObject;
            PlayerStats playerStats = player.GetComponent<PlayerStats>();
            //Weapon weapon = Weapon.GetComponent<Weapon>();
            //int damage = (weapon.bulletDamage);
            StartCoroutine(playerStats.TakeDamage(2, 1));
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    }
