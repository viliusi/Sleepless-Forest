using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public int numberOfHealing;
    public int numberOfSpeed;
    public int numberOfDamage;
    public int special;
    public TextMeshProUGUI healingNumberText;
    public TextMeshProUGUI speedNumberText;
    public TextMeshProUGUI damageNumberText;

    public bool PotionActive;

    // Beginning value for potions
    private void Start()
    {
        numberOfHealing = 0;
        numberOfSpeed = 0;
        numberOfDamage = 0;
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
                StartCoroutine(PotionDuration());
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
                StartCoroutine(PotionDuration());
            }
        }
    }

    // Timer for potions
    public IEnumerator PotionDuration()
    {
        PotionActive = true;
        yield return new WaitForSeconds(10);
        PotionActive = false;
    }
}
