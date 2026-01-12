using UnityEngine;

public class Interaction : MonoBehaviour, IInteractable
{
    public Transform InteractionSpot => interactionSpot;
    [SerializeField] private Transform interactionSpot;
    [SerializeField] private Material highlightedMaterial;
    [SerializeField] private Material normalMaterial;
    [SerializeField] private MeshRenderer meshRenderer;


    public void Interact()
    {
        print("Interact");
    }

    public void SetHighlighted(bool isHighlighted)
    {
        if(isHighlighted)
        {
            meshRenderer.material = highlightedMaterial;
        }
        else
        {
            meshRenderer.material = normalMaterial;
        }

    }
}
