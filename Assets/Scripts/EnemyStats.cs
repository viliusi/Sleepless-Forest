using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public float health;
    public float maxHealth = 10;
    public PlayerStats playerStats;
    public GameObject player;
    public Material[] material;
    public Renderer rend;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        player = GameObject.FindWithTag("PlayerTag");
        playerStats = player.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && health == 0)
        {
            Destroy(gameObject);
            playerStats.nightEssence += 1 + ((int)playerStats.insomnia * 10);
            playerStats.nightEssenceText.text = playerStats.nightEssence.ToString();
        }
    }

}
