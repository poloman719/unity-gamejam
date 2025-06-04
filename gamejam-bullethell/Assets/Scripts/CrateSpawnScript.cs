using UnityEngine;

public class CrateSpawnScript : MonoBehaviour
{
    // References
    public float generationRate;
    public GameObject crate;
    public GameObject stackedCrates;

    double timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        generationRate = Random.Range(0.9f,1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        int randCrate = Random.Range(0,2);
        float randPos = Random.Range(-9,-4);
        Vector3 pos = new Vector3(randPos,(float)6.4,1);
        timer += Time.deltaTime;
        if (timer > generationRate)
        {
            if(randCrate>0){
                Instantiate(crate, pos, transform.rotation);
            }
            else{
                Instantiate(stackedCrates, pos, transform.rotation);
            }
            generationRate = Random.Range(0.9f,1.2f);
            timer = 0;
        }
    }
}
