using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyDealDamage : MonoBehaviour
{
    public PlayerStats playerStats;
    public int damage;
    bool damagePossible;
    public int duration;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("PlayerTag");
        playerStats = player.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerTag")
        {
            StartCoroutine(playerStats.TakeDamage(damage, duration));
        }
    }
}
