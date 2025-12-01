using UnityEngine;

public class GunPickup : MonoBehaviour
{
    [SerializeField] Gun gunPrefab;

    private void OnTriggerEnter(Collider other)
    {
        Player player = GetComponent<Player>();
        if(player)
        {
            player.SwitchWeapon(gunPrefab);
        }
    }
}
