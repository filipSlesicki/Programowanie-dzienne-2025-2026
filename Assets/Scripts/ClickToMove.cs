using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class ClickToMove : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    [SerializeField] private float walkSpeed = 5;
    [SerializeField] private float runSpeed = 10;
    [SerializeField] private float interactionDistance = 1;
    private float speed = 5;
    private bool clicked;
    private bool moving;
    private IInteractable clickedInteraction;
    private IInteractable mouseOverInteraction;
    private NavMeshAgent agent;
    private RaycastHit mouseHitInfo; // Nad czym jest myszka

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (clickedInteraction != null)
        {
            if (Vector3.Distance(transform.position, clickedInteraction.InteractionSpot.position) < interactionDistance)
            {
                clickedInteraction.Interact();
                agent.isStopped = true;
                clickedInteraction = null;

            }
        }
    }

    private void OnClick()
    {
        agent.isStopped = false;
        clickedInteraction = mouseOverInteraction;
        if (clickedInteraction != null)
        {
            agent.SetDestination(clickedInteraction.InteractionSpot.position);
        }
        else
        {
            agent.SetDestination(mouseHitInfo.point);
        }

    }

    void OnMousePosition(InputValue inputValue)
    {
        if (mouseOverInteraction != null)
        {
            mouseOverInteraction.SetHighlighted(false);
            mouseOverInteraction = null;
        }
        Ray ray = Camera.main.ScreenPointToRay(inputValue.Get<Vector2>());
        if (Physics.Raycast(ray, out mouseHitInfo, 100, layer))
        {
            if (mouseHitInfo.collider.TryGetComponent(out IInteractable interaction))
            {
                mouseOverInteraction = interaction;
                interaction.SetHighlighted(true);
            }
        }
    }

    private void OnMouseClick(InputValue inputValue)
    {
        print(inputValue.isPressed);
        if (inputValue.isPressed)
        {
            agent.speed = walkSpeed;
            OnClick();
        }


    }
    private void OnDoubleClick(InputValue inputValue)
    {
        print(inputValue.isPressed);
        if (inputValue.isPressed)
        {
            agent.speed = runSpeed;
            OnClick();
        }
    }
}
