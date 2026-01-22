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
        Quaternion tenY = Quaternion.Euler(0, 10, 0);
        Quaternion rotation = transform.rotation;
        Quaternion sum = Quaternion.Inverse(tenY) * rotation; // kolejnoœæ ma znaczenie
        transform.rotation = sum;
        Vector3 rot = rotation * Vector3.forward;
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
