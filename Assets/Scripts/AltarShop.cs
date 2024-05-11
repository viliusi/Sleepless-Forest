using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AltarSho : MonoBehaviour
{
    public GameObject shopPopUp;
    public Animator animator;
    public TMP_Text itemName;
    public TMP_Text itemPrice;

    public void Shop(string name, int price)
    {
        shopPopUp.SetActive(true);
        itemName.text = name;
        itemPrice.text = price.ToString();

    }
}
