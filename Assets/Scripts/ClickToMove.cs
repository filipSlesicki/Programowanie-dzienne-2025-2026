using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickToMove : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    private Vector3 targetPosition;
    private Vector3 mousePosition;
    private float speed = 5;
    private bool clicked;
    private bool moving;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    void OnMousePosition(InputValue inputValue)
    {
        Ray ray = Camera.main.ScreenPointToRay(inputValue.Get<Vector2>());
        if (Physics.Raycast(ray, out RaycastHit hit, 100, layer))
        {
            mousePosition = hit.point;
        }
    }

    private void OnMouseClick()
    {
        targetPosition = mousePosition;
    }
}
