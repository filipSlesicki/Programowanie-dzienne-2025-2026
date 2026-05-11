using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TowerDefence
{
    public class TowerButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TMP_Text label;

        public void Setup(TowerData data, TowerBuilder builder)
        {
            button.onClick.AddListener(() => builder.StartBuildingTower(data));
            label.text = data.Name;
        }
    }
}
