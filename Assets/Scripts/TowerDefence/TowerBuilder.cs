using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace TowerDefence
{
    public class TowerBuilder : MonoBehaviour
    {
        [SerializeField] private InputActionAsset inputActions;
        [SerializeField]
        private LayerMask groundLayer;
        [SerializeField]
        TowerData[] availableTowers;
        [SerializeField]
        Transform towerButtonParent;
        [SerializeField]
        private TowerButton towerButtonPrefab;

        private InputAction mousePositionInput;
        private InputAction mouseClickInput;
        private Tower buildingTower;
        private Vector3 mouseWorldPosition;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            mousePositionInput = inputActions.FindAction("MousePosition");
            mousePositionInput.performed += OnMousePosition;
            mouseClickInput = inputActions.FindAction("MouseClick");
            mouseClickInput.performed += OnMouseClick;
            foreach (TowerData towerData in availableTowers)
            {
                TowerButton towerButton = Instantiate(towerButtonPrefab, towerButtonParent);
                towerButton.Setup(towerData, this);
            }
        }

        private void OnMousePosition(InputAction.CallbackContext context)
        {
            Ray ray = Camera.main.ScreenPointToRay(context.ReadValue<Vector2>());
            if (Physics.Raycast(ray, out RaycastHit hit, 100, groundLayer))
            {
                mouseWorldPosition = hit.point;
                if (buildingTower != null)
                {
                    buildingTower.transform.position = mouseWorldPosition;
                }
            }
        }
        private void OnMouseClick(InputAction.CallbackContext context)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            if (buildingTower)
            {
                buildingTower.Place();
                buildingTower = null;
            }
        }


        public void StartBuildingTower(TowerData towerData)
        {
            if(MoneyManager.Instance.TrySpendMoney(towerData.Price))
            {
                buildingTower = Instantiate(towerData.Prefab);
                buildingTower.Setup(towerData);
                buildingTower.transform.position = mouseWorldPosition;
            }
        }

    }
}
