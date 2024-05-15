using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AltarInteract : MonoBehaviour
{
    [SerializeField] private bool nearAltar = false;
    public AltarShop altarShop;
    public GameObject player;
    public bool shopDisplayed;

    private void Start()
    {
        player = GameObject.FindWithTag("PlayerTag");
        altarShop = player.GetComponent<AltarShop>();
        shopDisplayed = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerTag"))
        {
            nearAltar = true;
            altarShop.interactionPopUp.SetActive(true);
            altarShop.interactionPopUpText.text = "Press E to commune with altar";
            altarShop.interactionAnimator.SetTrigger("turnOn");
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerTag"))
        {
            nearAltar = false;
            altarShop.animator.SetTrigger("turnOff");
            shopDisplayed = false;
           altarShop.interactionAnimator.SetTrigger("turnOff");
        }
    }

    private void Update()
    {
        if (nearAltar && Input.GetKeyDown(KeyCode.E))
        {
            if (shopDisplayed == false)
            {
                altarShop.Shop();
                shopDisplayed = true;
            }
            else if (shopDisplayed == true)
            {
                altarShop.animator.SetTrigger("turnOff");
                shopDisplayed = false;
            }
        }
    }
}
