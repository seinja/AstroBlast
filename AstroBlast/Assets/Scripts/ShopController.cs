using System;
using TMPro;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    private int _speedLevel;
    private int _damageLevel;
    private int _speedUpdatePrice;
    private int _damageUpdatePrice;

    private Bank _bank;


    public delegate void SpeedHandler(int newValue, int speedUpdatePrice);
    public event SpeedHandler OnSpeedChagedEvent;

    public delegate void DamageHandler(int newValue, int damageUpdatePrice);
    public event DamageHandler OnDamageChagedEvent;


    private void Awake()
    {
        _bank = GetComponent<Bank>();
        _speedLevel = PlayerPrefs.GetInt("SpeedLevel", 4);
        _damageLevel = PlayerPrefs.GetInt("DamageLevel", 1);
        _speedUpdatePrice = PlayerPrefs.GetInt("SpeedUpdatePrice", 5);
        _damageUpdatePrice = PlayerPrefs.GetInt("DamageUpdatePrice", 10);
    }

    private void Start()
    {
        Debug.Log("Speed update price " + _speedUpdatePrice);
        Debug.Log("Damage update price " + _damageUpdatePrice);
    }


    public void UpdateSpeed() 
    {
        if (_bank.IsEnoughCoins(_speedUpdatePrice)) 
        {
            _bank.SpendCoins(this,_speedUpdatePrice);

            _speedLevel++;
            _speedUpdatePrice = _speedUpdatePrice * _speedLevel;

            this.OnSpeedChagedEvent?.Invoke(_speedLevel, _speedUpdatePrice);
        }
    }


    public void UpodateDamage() 
    {
        if (_bank.IsEnoughCoins(_damageUpdatePrice)) 
        {
            _bank.SpendCoins(this, _damageUpdatePrice);

            _damageLevel++;
            _damageUpdatePrice = _damageUpdatePrice * _damageLevel;

            this.OnDamageChagedEvent?.Invoke(_damageLevel, _damageUpdatePrice);
        }

    }

    public int GetDamageLevel => _damageLevel;
    public int GetSpeedLevel => _speedLevel;

    public int GetDamagePrice => _damageUpdatePrice;
    public int GetSpeedPrice => _speedUpdatePrice;


















}
