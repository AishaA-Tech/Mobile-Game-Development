using UnityEngine;
using System.Collections;

public class infiniteScroll : MonoBehaviour
{
    public float scroll_speed = 0.5f;
    private MeshRenderer layer_renderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        layer_renderer = GetComponent<MeshRenderer>(); //Getting the layer's mesh renderer
    }

    // Update is called once per frame
    void Update()
    {
        layer_renderer.material.mainTextureOffset = new Vector2(Time.time * scroll_speed, 0f);
        // Moving the material on the quad infinitely at a specific speed
    }
}
