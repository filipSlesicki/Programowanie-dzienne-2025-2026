using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public Transform InteractionSpot => interactionSpot;
    [SerializeField] private Transform interactionSpot;
    [SerializeField] private Material highlightedMaterial;
    [SerializeField] private Material normalMaterial;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Item[] items;


    public void Interact()
    {
        print(GetRandomItem());
    }

    private string GetRandomItem()
    {
        float totalChance = 0;
        foreach (var item in items)
        {
            totalChance += item.DropChance;
        }
        float randomValue = Random.Range(0, totalChance);
        foreach(var item in items)
        {
            randomValue -= item.DropChance;
            if(randomValue <= 0)
            {
                return item.Name;
            }
        }
        Debug.LogError("No item found");
        return items[Random.Range(0, items.Length)].Name;
    }

    public void SetHighlighted(bool isHighlighted)
    {
        if (isHighlighted)
        {
            meshRenderer.material = highlightedMaterial;
        }
        else
        {
            meshRenderer.material = normalMaterial;
        }

    }
}
