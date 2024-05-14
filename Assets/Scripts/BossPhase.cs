using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform firePoint;
    private Transform player;

    public EnemyStats enemyStats;
    
    public MapManager mapManager;

    bool spawnCooldown;
    public int spawnCooldownDuration;
    public bool IsActive = false;

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

                Enemy enemyScript = GetComponent<Enemy>();

                enemyScript.IsActive = true;

                StartCoroutine(SpawnCooldown());
            }
            
            

        }
        // Boss death function
        if (enemyStats.health <= 0) 
        {
            // mapManager.NightCount += 1;

            mapManager.Restart();

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
