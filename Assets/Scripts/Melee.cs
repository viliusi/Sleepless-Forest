using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public Transform Player;

    private float damage;

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
                other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
    }

