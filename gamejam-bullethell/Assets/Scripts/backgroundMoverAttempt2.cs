using UnityEngine;
using UnityEngine.UI;

public class backgroundMoverAttempt2 : MonoBehaviour
{
    // References
    public Renderer bgRenderer;
    public float scrollSpeed;

    // Update is called once per frame
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(0, scrollSpeed * Time.deltaTime);
    }
}
