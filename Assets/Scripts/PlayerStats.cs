using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public bool damagePossible;
    public float damageMultiplier;
    public Image healthBar;
    public TMP_Text healthValuesText;
    public Animator animator;
    bool healthValuesOn;
    public float insomnia;
    public int nightEssence;
    public TextMeshProUGUI nightEssenceText;
    public Image[] EndPrompts;
    public TextMeshProUGUI[] EndTexts;
    public bool CanProgress;
    public MapManager mapManager;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        damagePossible = true;
        CanProgress = false;
        insomnia = 0;
        healthValuesOn = true;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            insomnia += 0.1f;
            print("Isnomnia is: " + insomnia);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (healthValuesOn == true) {
                animator.SetTrigger("turnOff");
                healthValuesOn = false;
            }
            else
            {
                animator.SetTrigger("turnOn");
                healthValuesOn = true;
            }
        }
    }

    //amount being damage to be dealt; duration being the number of times this occurs
    public IEnumerator TakeDamage(int amount, int duration)
    {
        if (damagePossible == true)
        {
            for (int i = duration; i > 0; i--)
            {
                health -= (amount + (amount * insomnia));
                healthBar.fillAmount = health / maxHealth;
                healthValuesText.text = health.ToString() + "/" + maxHealth.ToString();
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