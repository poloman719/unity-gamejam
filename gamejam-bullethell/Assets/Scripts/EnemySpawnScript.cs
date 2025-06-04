using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject[] possibleEnemies;
    public int[] enemyWeights;
    public int currentWeight = 0;
    public int maxWeight = 0;
    public int maxWeightLimit = 4;
    public bool canSpawn = true;
    public double spawnTimer = 10;
    public double timer;
    public GameObject[] currentEnemies;
    public GameObject[] temp;
    public int enemiesKilled = 0;
    public double timeAlive = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxWeight = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;
        if (!canSpawn) return;
        timer += Time.deltaTime;
        if (timer > spawnTimer)
        {
            timer = 0;
            int spawnCandidate = Random.Range(0, possibleEnemies.Length);
            if (currentWeight + enemyWeights[spawnCandidate] <= maxWeight)
            {
                switch (spawnCandidate)
                {
                    case 0:
                        spawnRedWizard();
                        break;
                    case 1:
                        spawnYellowWizard();
                        break;
                }
            }
        }
    }

    [ContextMenu("Spawn Red Wizard")]
    void spawnRedWizard()
    {
        int direction = Random.Range(0, 2);
        if (direction == 0)
        {
            direction = -1;
        }
        Vector2 spawnPos = new Vector2((float)(-6.5 + (7.5 * direction)), Random.Range((float)2.5, (float)3));
        GameObject spawnedWizard = Instantiate(possibleEnemies[0], spawnPos, transform.rotation);
        spawnedWizard.GetComponent<WizardScript>().removeSelf = () =>
        {
            currentWeight -= enemyWeights[0];
            killAnEnemy();
        };
        currentWeight += enemyWeights[0];
    }

    [ContextMenu("Spawn Yellow Wizard")]
    void spawnYellowWizard()
    {
        int direction = Random.Range(0, 2);
        if (direction == 0)
        {
            direction = -1;
        }
        Vector2 spawnPos = new Vector2((float)(-6.5 + (7.5 * direction)), Random.Range((float)3, (float)3.25));
        GameObject spawnedWizard = Instantiate(possibleEnemies[1], spawnPos, transform.rotation);
        spawnedWizard.GetComponent<YellowWizardScript>().removeSelf = () =>
        {
            currentWeight -= enemyWeights[1];
            killAnEnemy();
        };
        currentWeight += enemyWeights[1];
    }

    void killAnEnemy()
    {
        enemiesKilled += 1;
        if (enemiesKilled % 2 == 0 && enemiesKilled <= maxWeightLimit * 2)
        {
            maxWeight += 1;
        } 
    }
}
