using UnityEngine;

public class YellowBeamScript : MonoBehaviour
{
    public double fireTime;
    double timer;
    public Animator anim;
    public GameObject itself;
    public AudioSource beamStart;
    public AudioSource beamFire;
    public BoxCollider2D bc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        beamStart.Play();
        beamFire.PlayDelayed((float) 1.8);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.8){
            bc.enabled = true;
        }
        if (timer > fireTime)
        {
            anim.SetTrigger("Ending");
            beamFire.volume -= (float)1 * Time.deltaTime;
            bc.enabled = false;
        }
        if (timer > (fireTime + 1.542))
        {
            Destroy(itself);
        }
    }
}
