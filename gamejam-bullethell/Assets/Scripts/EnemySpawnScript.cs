using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject[] possibleEnemies;
    public int[] enemyWeights;
    public int currentWeight = 0;
    public int maxWeight = 0;
    public bool canSpawn = true;
    public double spawnTimer = 10;
    public double timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
        Instantiate(possibleEnemies[0], spawnPos, transform.rotation);
        currentWeight += enemyWeights[0];
    }
    
    [ContextMenu("Spawn Yellow Wizard")]
    void spawnYellowWizard()
    {
        int direction = Random.Range(0, 2);
        if (direction == 0) {
            direction = -1;
        }
        Vector2 spawnPos = new Vector2((float) (-6.5 + (7.5 * direction)), Random.Range((float)3, (float)3.25));
        Instantiate(possibleEnemies[1], spawnPos, transform.rotation);
        currentWeight += enemyWeights[1];
    }
}
