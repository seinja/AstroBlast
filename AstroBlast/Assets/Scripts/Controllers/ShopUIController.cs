using UnityEngine;
using TMPro;

public class ShopUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _speedPriceText, _speedText, _allMoneyText, _damageText, _damagePriceText;

    private Bank _bank;
    private ShopController _shopController;

    private void Awake()
    {
        _bank = GetComponent<Bank>();
        _shopController = GetComponent<ShopController>();

        _bank.OnCoinsValueChagedEvent += OnCoinsChaged;
        _shopController.OnSpeedChagedEvent += OnSpeedPriceChanged;
        _shopController.OnDamageChagedEvent += OnDamagePriceChaged;
    }

    private void Start()
    {
        InitUI();
    }

    private void OnDamagePriceChaged(int newValue, int damageUpdatePrice)
    {
        _damageText.text = newValue.ToString();
        _damagePriceText.text = damageUpdatePrice.ToString();
    }

    private void OnSpeedPriceChanged(int newValue, int speedUpdatePrice)
    {
        _speedText.text = newValue.ToString();
        _speedPriceText.text = speedUpdatePrice.ToString();
    }

    private void OnCoinsChaged(object sender, int oldCoinsValue, int newCoinsValue)
    {
        _allMoneyText.text = _bank.GetCoins.ToString();
    }

    private void InitUI() 
    {
        _speedPriceText.text = _shopController.GetSpeedPrice.ToString();
        _speedText.text = _shopController.GetSpeedLevel.ToString();

        _damagePriceText.text = _shopController.GetDamagePrice.ToString();
        _damageText.text = _shopController.GetDamageLevel.ToString();
    }
}
