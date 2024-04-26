using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public bool damagePossible;
    public float insomnia;
    public Image healthBar;
    public Image SleepPrompt;
    public Image CampfirePrompt;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        damagePossible = true;
    }


    // Update is called once per frame

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
                else
                {
                }
            }

        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EndTrigger")
        {
            // unhide the campfire and sleep prompts

            print("entered");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EndTrigger")
        {
            // hide campfire and sleep prompts and their texts

            print("exited");
        }
    }
}

