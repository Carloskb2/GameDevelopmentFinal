using UnityEngine;

public class ShaderToggle : MonoBehaviour
{
    public Shader grayscaleShader;
    public CollectableID myID; // The ID this object responds to
    private Shader originalShader;
    private Material tilemapMaterial;

    private bool isGrayscale = true;

    void Start()
    {
        tilemapMaterial = GetComponent<Renderer>().material;
        originalShader = tilemapMaterial.shader;
        ToggleShader(isGrayscale);
        Collectable.OnCollected += HandleCollectableCollected;
    }

    void OnDestroy()
    {
        Collectable.OnCollected -= HandleCollectableCollected;
    }

    private void HandleCollectableCollected(CollectableID id)
    {
        if (myID == id)
        {
            isGrayscale = !isGrayscale;
            ToggleShader(isGrayscale);
        }
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
