using TMPro;
using UnityEngine;

namespace TowerDefence
{
    public class MoneyManager : MonoBehaviour
    {
        public static MoneyManager Instance;
        public int Money { get; private set; } = 100;
        [SerializeField]
        private TMP_Text moneyLabel;
        private void Awake()
        {
            Instance = this;
            moneyLabel.text = Money.ToString();
        }

        public bool TrySpendMoney(int amount)
        {
            if(Money < amount)
            {
                return false;
            }
            Money -= amount;
            moneyLabel.text = Money.ToString();
            return true;
        }

        public void AddMoney(int amount)
        {
            Money += amount;
            moneyLabel.text = Money.ToString();
        }
    }
}
