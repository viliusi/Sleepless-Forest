using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform firePoint;
    private Transform player;

    public EnemyStats enemyStats;

    bool spawnCooldown;
    public int spawnCooldownDuration;

    // Start is called before the first frame update
    void Start()
    {
        enemyStats.health = 50;
        spawnCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Boss second phase/enemy spawn funktion
        if (enemyStats.health <= 25)
        {
            if (spawnCooldown == false)
            {
                spawnCooldown = true;




                GameObject enemy = Instantiate(enemyPrefab, firePoint.position, firePoint.rotation);

                StartCoroutine(SpawnCooldown());
            }
            
            

        }
        // Boss death funktion
        if (enemyStats.health <= 0) 
        {
            Destroy(gameObject);
        }
    }

    // Enemy spawn cooldown
    private IEnumerator SpawnCooldown() 
    {
        
            spawnCooldown = true;
            yield return new WaitForSeconds(spawnCooldownDuration);
            spawnCooldown = false;
        
    }
}
