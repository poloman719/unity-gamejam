using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    public GameObject HeartPrefab;
    public Sprite HeartLiveSprite;
    public Sprite HeartDeadSprite;
    public int heartSpacing = 30;
    public int maxHearts = 5;
    public int currHearts;
    public Vector3 heartStartPos = new Vector3();
    public List<GameObject> heartObjects;
    public AudioSource damage;

    void Start()
    {
        currHearts = maxHearts;
        for (int i = 0; i < maxHearts; i++)
        {
            Vector3 spawnPos = heartStartPos;
            spawnPos.x += i * heartSpacing;
            GameObject newHeart = Instantiate(HeartPrefab, spawnPos, Quaternion.identity);
            newHeart.transform.SetParent(gameObject.transform);
            heartObjects.Add(newHeart);
        }
    }

    public void takeDamage(int amount)
    {
        if (currHearts > 0)
        {
            currHearts -= amount;
        }
        else
        {
            Debug.Log("died");
            PlayerController player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
            player.OnDeath();
        }
        heartObjects[currHearts].GetComponent<Image>().sprite = HeartDeadSprite;
    }
}
