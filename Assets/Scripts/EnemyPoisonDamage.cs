using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoisonDamage : MonoBehaviour
{
    public PlayerStats playerStats;
    public int poisonDamage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerTag")
        {
            StartCoroutine(Poisoned());
        }
    }

    private IEnumerator Poisoned() 
    {
        for (int i = 0; i <5; i++)
        {
            playerStats.TakeDamage(poisonDamage);
            print("Player is taking poison damage");
            yield return new WaitForSeconds(1f);
        }
    }

}
