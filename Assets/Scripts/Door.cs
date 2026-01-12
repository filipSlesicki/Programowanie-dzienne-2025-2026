using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [field: SerializeField] public Transform InteractionSpot { get; private set; }
    [SerializeField] private Material highlightedMaterial;
    [SerializeField] private Material normalMaterial;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Transform pivot;
    float targetRotation => isOpen ? 0 : 90;
    private bool isOpen;
    //public Transform InteractionSpot2 { get;private set; }
    //public Transform InteractionSpot3  => interactionSpot;

    //public Transform InteractionSpot
    //{
    //    get {
    //        print(interactionSpot.position);
    //        return interactionSpot; }
    //    set { interactionSpot = value; }
    //}

    public void Interact()
    {
        print("Interact with door");
        isOpen = !isOpen;
        
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

    private void Update()
    {
        Quaternion targetRot = Quaternion.Euler(0, targetRotation, 0);
        pivot.rotation = Quaternion.Slerp(pivot.rotation, targetRot, 5 * Time.deltaTime);
    }
}
