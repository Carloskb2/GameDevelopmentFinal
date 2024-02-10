using UnityEngine;

public class ColliderToggle : MonoBehaviour
{
    public CollectableID myID; // The ID this object responds to
    private BoxCollider2D bc2D;

    void Start()
    {
        bc2D = GetComponent<BoxCollider2D>();
        bc2D.enabled = false;

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
            bc2D.enabled = true;
        }
    }
}
