using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Transform InteractionSpot;
    [SerializeField] private Material highlightedMaterial;
    [SerializeField] private Material normalMaterial;
    [SerializeField] private MeshRenderer meshRenderer;

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
