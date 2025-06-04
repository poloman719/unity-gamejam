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
            Instantiate(house, new Vector3((float)-11.5, (float)6.4, 1), transform.rotation);
            Instantiate(house, new Vector3((float)-2, (float)6.4, 1), transform.rotation);
            timer = 0;
        }
    }
}
