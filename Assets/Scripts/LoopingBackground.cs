using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    public float speed;
    public Renderer backgroundRenderer;

    void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0f);
    }
}