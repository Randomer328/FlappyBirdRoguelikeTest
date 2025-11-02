using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    public float scrollSpeed = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0); 
    }
}
    