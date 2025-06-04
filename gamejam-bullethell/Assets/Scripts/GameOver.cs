using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject EnemiesKilledText;
    public GameObject TimeAliveText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemySpawnScript spawner = GameObject.FindWithTag("Spawner").GetComponent<EnemySpawnScript>();
        int enemiesKilled = spawner.enemiesKilled;
        string timeAlive = spawner.timeAlive.ToString("N2");
        EnemiesKilledText.GetComponent<TMP_Text>().text = "Enemies Killed: " + enemiesKilled;
        TimeAliveText.GetComponent<TMP_Text>().text = "Time Alive: " + timeAlive + "s";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
