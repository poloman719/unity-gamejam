using UnityEngine;

public class BuildingSpawnScript : MonoBehaviour
{
    // References
    public double generationRate;
    public GameObject house;

    double timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > generationRate)
        {
            Instantiate(house, new Vector2((float)-8.7, (float)6.4), transform.rotation);
            Instantiate(house, new Vector2((float)-1.25, (float)6.4), transform.rotation);
            timer = 0;
        }
    }
}
