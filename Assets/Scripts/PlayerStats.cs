using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float insomnia;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        // public Slider healthBar;
    }

    // Update is called once per frame
    public void TakeDamage(int amount)
    {
        health -= amount;
        print(health);

        if(health <= 0)
        {
            Destroy(gameObject);

        }
    }
}
