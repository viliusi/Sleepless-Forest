using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int numberOfHealing;
    public int numberOfSpeed;
    public int numberOfDamage;

    public TextMeshProUGUI healingNumberText;
    public TextMeshProUGUI speedNumberText;
    public TextMeshProUGUI damageNumberText;

    public bool SpeedActive;

    public bool DamageActive;

    public float SpeedDuration;

    public float DamageDuration;

    public bool HealingPossible;

    public int HAmount;

    public int Duration;

    public int DAmount;

    public int DDuration;

    public int SAmount;

    public int SDuration;

    public PlayerMovement playerMovement;
    public Weapon weapon;
    public PlayerStats playerStats;
    public Image healthBar;

    // Beginning value for potions
    private void Start()
    {
        numberOfHealing = 0;
        numberOfSpeed = 0;
        numberOfDamage = 0;
        
        HealingPossible = true;
        playerStats.health = playerStats.maxHealth;

        SpeedActive = true;
        DamageActive = true;
    }

    // Shows the number of potions collected
    private void Update()
    { 
        healingNumberText.text = numberOfHealing.ToString();
        speedNumberText.text = numberOfSpeed.ToString();
        damageNumberText.text = numberOfDamage.ToString();

        // Using health potions
        if (numberOfHealing > 0)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                print("Health potion used!");
                numberOfHealing--;
                healingNumberText.text = healingNumberText.ToString();
                StartCoroutine(HealEffect(HAmount, Duration));
            }
        }

        // Using speed potions
        if (numberOfSpeed > 0)
        {
            if (Input.GetKey(KeyCode.Alpha2))
            {
                print("Speed potion used!");
                numberOfSpeed--;
                speedNumberText.text = speedNumberText.ToString();
                StartCoroutine(SpeedBoost(SAmount, SDuration));
            }
        }

        // Using damage potions
        if (numberOfDamage > 0)
        {
            if (Input.GetKey(KeyCode.Alpha3))
            {
                print("Damage potion used!");
                numberOfDamage--;
                damageNumberText.text = damageNumberText.ToString();
                StartCoroutine(DamageBoost(DAmount, DDuration));
            }
        }
    }

    // Healing effect
    public IEnumerator HealEffect(int HAmount, int Duration)
    {
        if (HealingPossible == true)
        {
            for (int i = Duration; i > 0; i--)
            {
                playerStats.health += HAmount;
                healthBar.fillAmount = playerStats.health * 1;
                yield return new WaitForSeconds(1f);
            }
        }
    }

    // Timer for Speed effect
    public IEnumerator SpeedBoost(int SAmount, int SDuration) 
    {
        if (SpeedActive == true)
        {
            for (int i = SDuration; i > 0; i--)
            {
                playerMovement.Speed += SAmount;
                playerMovement.Speed = playerMovement.Speed * 1;
                yield return new WaitForSeconds(1f);
            }
        }
    }

    // Timer for Damage effect
    public IEnumerator DamageBoost(int DAmount, int DDuration) 
    {
        if (DamageActive == true)
        {
            for (int i = DDuration; i > 0; i--)
            {
                weapon.bulletDamage += DAmount;
                weapon.bulletDamage = weapon.bulletDamage * 1;
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
