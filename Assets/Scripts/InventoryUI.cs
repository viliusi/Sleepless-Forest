using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI HealingNumber;

    // Start is called before the first frame update
    void Start()
    {
        HealingNumber = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealingNumber(Inventory inventory)
    {
        HealingNumber.text = inventory.numberofhealing.ToString();
    }
}
