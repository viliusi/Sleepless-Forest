using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public bool damagePossible;
    public Image healthBar;
    public float insomnia;
    public int nightEssence;
    public TextMeshProUGUI nightEssenceText;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        damagePossible = true;
        insomnia = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            insomnia += 0.1f;
            print("Insomnia is" + insomnia);
        }
    }

    // Update is called once per frame

    //amount being damage to be dealt; duration being the number of times this occurs
    public IEnumerator TakeDamage(int amount, int duration)
    {
        if (damagePossible == true)
        {
            for (int i = duration; i > 0; i--)
            {
                health -= (amount + (amount * insomnia));
                healthBar.fillAmount = health / 100;
                print("health is now " + health);
                yield return new WaitForSeconds(1f);

                if (health <= 0)
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }
}
