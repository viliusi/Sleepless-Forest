using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public bool damagePossible;
    public float insomnia;
    public Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        damagePossible = true;
    }

    // Update is called once per frame
    public void TakeDamage(int amount)
    {
        if (damagePossible == true) 
        {
            health -= amount;
            healthBar.fillAmount = health / 10;
            if(health <= 0)
            {
                Destroy(gameObject);

            }
        }
}
}
