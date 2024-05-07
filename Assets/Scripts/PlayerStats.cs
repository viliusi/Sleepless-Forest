using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public bool damagePossible;
    public float insomnia;
    public Image healthBar;
    public Image[] EndPrompts;
    public TextMeshProUGUI[] EndTexts;
    public bool CanProgress;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        damagePossible = true;
        CanProgress = true;

        GameObject canvas = GameObject.Find("Canvas");

        if (canvas != null)
        {
            // Get all Image components and filter by tag
            Image[] allImages = canvas.GetComponentsInChildren<Image>(true);
            EndPrompts = Array.FindAll(allImages, img => img.CompareTag("EndUI"));

            // Get all TextMeshProUGUI components
            EndTexts = canvas.GetComponentsInChildren<TextMeshProUGUI>(true);
        }
        else
        {
            Debug.LogError("No GameObject named 'Canvas' found.");
        }

        foreach (var prompt in EndPrompts)
        {
            prompt.enabled = false;
        }

        foreach (var text in EndTexts)
        {
            text.enabled = false;
        }
    }

    //amount being damage to be dealt; duration being the number of times this occurs
    public IEnumerator TakeDamage(int amount, int duration)
    {
        if (damagePossible == true)
        {
            for (int i = duration; i > 0; i--)
            {
                health -= amount;
                healthBar.fillAmount = health / 10;
                yield return new WaitForSeconds(1f);
                if (health <= 0)
                {
                    SceneManager.LoadScene(0);
                }
                else { }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EndTrigger")
        {
            // unhide the campfire and sleep prompts
            foreach (var prompt in EndPrompts)
            {
                prompt.enabled = true;
            }

            foreach (var text in EndTexts)
            {
                text.enabled = true;
            }

            CanProgress = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EndTrigger")
        {
            // hide campfire and sleep prompts and their texts
            foreach (var prompt in EndPrompts)
            {
                prompt.enabled = false;
            }

            foreach (var text in EndTexts)
            {
                text.enabled = false;
            }

            CanProgress = false;
        }
    }
}