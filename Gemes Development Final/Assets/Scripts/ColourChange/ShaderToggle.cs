using UnityEngine;

public class ShaderToggle : MonoBehaviour
{
    public Shader grayscaleShader;
    private Shader originalShader;
    private Material tilemapMaterial;

    private bool isGrayscale = true; // Start with grayscale

    void Start()
    {
        tilemapMaterial = GetComponent<Renderer>().material;
        originalShader = tilemapMaterial.shader;

        // Apply grayscale shader initially
        ToggleShader(isGrayscale);

        Collectable.OnCollected += HandleCollectableCollected; // Subscribe to the event
    }

    void OnDestroy()
    {
        Collectable.OnCollected -= HandleCollectableCollected; // Unsubscribe from the event
    }

    private void HandleCollectableCollected()
    {
        isGrayscale = !isGrayscale; // Toggle the state
        ToggleShader(isGrayscale);
    }

    public void ToggleShader(bool toGrayscale)
    {
        if (toGrayscale)
        {
            tilemapMaterial.shader = grayscaleShader;
        }
        else
        {
            tilemapMaterial.shader = originalShader;
        }
    }
}
