using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDealDamage : MonoBehaviour
{
    public PlayerStats playerStats;
    public int damage;
    bool damagePossible;
    // Start is called before the first frame update
    void Start()
    {
        // Get player stats script reference
        playerStats = GameObject.FindWithTag("PlayerTag").GetComponent<"PlayerStats.cs">;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PlayerTag")
        {
            playerStats.TakeDamage(damage);
        }
    }
}
