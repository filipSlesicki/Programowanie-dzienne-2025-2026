using UnityEngine;

public interface IInteractable
{
    public Transform InteractionSpot { get; }
    void Interact();
    void SetHighlighted(bool isHighlighted);
}
