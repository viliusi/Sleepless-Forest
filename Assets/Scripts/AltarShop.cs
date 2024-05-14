using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Purchasing;

public class AltarShop : MonoBehaviour
{
    public PlayerStats playerStats;
    public GameObject shopPopUp;
    public Animator animator;
    public TMP_Text priceHealthText;
    public TMP_Text priceDamageText;
    public int priceHealth;
    public int priceDamage;
    public TMP_Text damageMultiplierText;
    public GameObject interactionPopUp;
    public TMP_Text interactionPopUpText;
    public Animator interactionAnimator;

    public void Shop()
    {
        shopPopUp.SetActive(true);
        priceHealthText.text = priceHealth.ToString();
        priceDamageText.text = priceDamage.ToString();
        animator.SetTrigger("turnOn");

    }

    public void buyHealthUpgrade()
    {
        if (playerStats.nightEssence >= priceHealth)
        {
            playerStats.nightEssence -= priceHealth;
            playerStats.health += ((playerStats.maxHealth / 100) * 20);
            playerStats.maxHealth += ((playerStats.maxHealth / 100)*20);
            playerStats.nightEssenceText.text = playerStats.nightEssence.ToString();
            playerStats.healthBar.fillAmount = playerStats.health / playerStats.maxHealth;
            playerStats.healthValuesText.text = playerStats.health.ToString() + "/" + playerStats.maxHealth.ToString();
            priceHealth *= 2;
            priceHealthText.text = priceHealth.ToString();
        }
        else
        {
            print("not enough essence");
        }
    }

    public void buyDamageUpgrade()
    {
        if(playerStats.nightEssence >= priceDamage)
        {
            playerStats.nightEssence -= priceDamage;
            playerStats.damageMultiplier += 0.2f;
            playerStats.nightEssenceText.text = playerStats.nightEssence.ToString();
            damageMultiplierText.text = "x" + playerStats.damageMultiplier.ToString();
            priceDamage *= 2;
            priceDamageText.text = priceDamage.ToString();
        }
        else
        {
            print("not enough essence");
        }
    }

}