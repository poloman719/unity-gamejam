using UnityEngine;

public class YellowBeamScript : MonoBehaviour
{
    public double fireTime;
    double timer;
    public Animator anim;
    public GameObject itself;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > fireTime)
        {
            anim.SetTrigger("Ending");
        }
        if (timer > (fireTime + 1.542))
        {
            Destroy(itself);
        }
    }
}
