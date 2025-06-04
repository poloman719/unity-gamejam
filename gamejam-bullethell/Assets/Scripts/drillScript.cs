using UnityEngine;

public class drillScript : MonoBehaviour
{
    double timer = 0;
    public double releaseTimer = 1;
    public GameObject debris;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > releaseTimer)
        {
            debrisRelease();
            timer = 0;
        }
    }

    [ContextMenu("Release Debris")]
    public void debrisRelease()
    {
        Instantiate(debris, transform.position, Quaternion.Euler(new Vector3(0, 0, transform.rotation.z)));
        Instantiate(debris, transform.position, Quaternion.Euler(new Vector3(0, 0, 180 + transform.rotation.z)));
    }
}
