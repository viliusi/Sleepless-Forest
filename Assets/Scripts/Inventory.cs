using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public int numberofhealing;
    public int numberofspeed;
    public int numberofdamage;
    public int special;

    public UnityEvent<Inventory> OnHealingCollected;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HealingCollected()
    {
        numberofhealing++;
        OnHealingCollected.Invoke(this);
    }
}
