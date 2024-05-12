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


    public void Shop()
    {
        shopPopUp.SetActive(true);
        priceHealthText.text = priceHealth.ToString();
        priceDamageText.text = priceDamage.ToString();
        animator.SetTrigger("turnOn");

    }

    public void buyUpgrade()
    {
        if(playerStats.nightEssence == priceDamage || playerStats.nightEssence > priceDamage)
        {
            playerStats.nightEssence -= priceDamage;
            playerStats.damageMultiplier += 0.2f;
            print("damage multiplier now" + playerStats.damageMultiplier);
        }
        else
        {
            print("not enough essence");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)){
            Shop();
        }
    }

}