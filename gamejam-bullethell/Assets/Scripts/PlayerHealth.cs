using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject HeartPrefab;
    public Sprite HeartLiveSprite;
    public Sprite HeartDeadSprite;
    public int heartSpacing = 30;
    public int maxHearts = 5;
    public int currHearts;
    public Vector3 heartStartPos = new Vector3();

    void Start()
    {
        currHearts = maxHearts;
        for (int i = 0; i < maxHearts; i++)
        {
            Vector3 spawnPos = heartStartPos;
            spawnPos.x += i * heartSpacing;
            GameObject newHeart = Instantiate(HeartPrefab, spawnPos, Quaternion.identity);
            newHeart.transform.SetParent(gameObject.transform);
            // heartObjects.Add(newHeart);
        }
    }

    public void takeDamage()
    {
        currHearts -= 1;
        // heartObjects[currHearts].GetComponent<Image>().sprite = HeartDeadSprite;
    }
}
