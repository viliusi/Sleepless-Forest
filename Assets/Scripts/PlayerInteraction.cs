using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject interactionPopUp;
    public TMP_Text interactionPopUpText;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void interactionNotice(string actionDescription)
    {
        interactionPopUp.SetActive(true);
        interactionPopUpText.text = "Press E to" + actionDescription;
        animator.SetTrigger("turnOn");
    }
}
