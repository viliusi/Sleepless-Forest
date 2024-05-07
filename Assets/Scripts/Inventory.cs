using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public int numberOfHealing;
    public int numberOfSpeed;
    public int numberofdamage;
    public int special;
    public TextMeshProUGUI healingNumberText;

    private void Start()
    {
        numberOfHealing = 0;
    }

    private void Update()
    { 
        healingNumberText.text = numberOfHealing.ToString();
    }
}
