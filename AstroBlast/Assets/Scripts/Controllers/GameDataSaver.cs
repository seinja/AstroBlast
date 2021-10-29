using System;
using UnityEngine;

public class GameDataSaver : MonoBehaviour
{

    private Bank _bank;
    private ShopController _shopController;

    private int _speedUpdateLevel;
    private int _damageUpdateLevel;

    private int _safeCoins;

    private int _lastLevel;

    private void Awake()
    {
        _bank = GetComponent<Bank>();
        _shopController = GetComponent<ShopController>();

        _shopController.OnDamageChagedEvent += DamageChageSafe;
        _shopController.OnSpeedChagedEvent += SpeedChangeSafe;

        SafeData();
    }

    private void SpeedChangeSafe(int newValue, int speedUpdatePrice)
    {
        PlayerPrefs.SetInt("SpeedLevel", newValue);
    }

    private void DamageChageSafe(int newValue, int damageUpdatePrice)
    {
        PlayerPrefs.SetInt("DamageLevel", newValue);
    }

    public void ResetProgres() 
    {
        PlayerPrefs.DeleteAll();
    }

    public void GetDataFromControllers() 
    {
        _safeCoins = _bank.GetCoins;

        _speedUpdateLevel = _shopController.GetSpeedLevel;
        _damageUpdateLevel = _shopController.GetDamageLevel;

        _lastLevel = GameManager.Instance.GetCurrentLevel();

    }

    public void SafeData() 
    {
        GetDataFromControllers();

        PlayerPrefs.SetInt("SafeCoins", _safeCoins);

        PlayerPrefs.SetInt("DamageLevel", _damageUpdateLevel);
        PlayerPrefs.SetInt("SpeedLevel", _speedUpdateLevel);

        PlayerPrefs.SetInt("GameLevel", _lastLevel);

        PlayerPrefs.SetInt("SpeedUpdatePrice", _shopController.GetSpeedPrice);
        PlayerPrefs.SetInt("DamageUpdatePrice", _shopController.GetDamagePrice);
    }

    public void OnDisable()
    {
        SafeData();
    }

}
