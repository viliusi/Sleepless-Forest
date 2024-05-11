using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public bool damagePossible;
    public float insomnia;
    public Image healthBar; 
    public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        damagePossible = true;
    }


    // Update is called once per frame
    void Update()
    {

    }

    //amount being damage to be dealt; duration being the number of times this occurs
    public IEnumerator TakeDamage(int amount, int duration)
    {
        if(damagePossible == true)
            {
            for (int i = duration; i > 0; i--)
            {
                health -= amount;
                healthBar.fillAmount = health / 10;
                yield return new WaitForSeconds(1f);
                if (health <= 0)
                {
                    SceneManager.LoadScene(0);
                }
                else
                {
                }
        }

    }
    }
    // When colliding with potions
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HealingTag")
        {
            print("Healing Potion collected!");  
            inventory.numberOfHealing++;
            inventory.healingNumberText.text = inventory.healingNumberText.ToString();
            Destroy(other.transform.gameObject);
        }

        if (other.gameObject.tag == "SpeedTag")
        {
            print("Speed Potion collected!");
            inventory.numberOfSpeed++;
            inventory.speedNumberText.text = inventory.speedNumberText.ToString();
            Destroy(other.transform.gameObject);
        }

        if (other.gameObject.tag == "DamageTag")
        {
            print("Damage Potion collected!");
            inventory.numberOfDamage++;
            inventory.damageNumberText.text = inventory.damageNumberText.ToString();
            Destroy(other.transform.gameObject);
        }
    }
}
