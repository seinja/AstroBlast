using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _speedPriceText, _speedText, _allMoneyText, _damageText, _damagePriceText;

    private int _allMoney;

    private int _updateSpeedLevel;
    private float _speed;
    private int _speedPrice;

    private int _updateDamageLevel;
    private int _shopDamage;
    private int __damagePrice;
    

    private Bullet _bulletController;
    


    private void Awake()
    {
        _updateSpeedLevel = PlayerPrefs.GetInt("SpeedLevel", 4);
        _speedPrice = PlayerPrefs.GetInt("UpdateSpeedPrice", 5); 
        _speed = 1f / _updateSpeedLevel;

        _updateDamageLevel = PlayerPrefs.GetInt("DamageLevel", 1);
        _shopDamage = _updateDamageLevel;
        __damagePrice = PlayerPrefs.GetInt("UpdateDamagePrice", 8);



        _speedText.text = Mathf.Round(1 / _speed).ToString();
        _speedPriceText.text = _speedPrice.ToString();


        _bulletController = FindObjectOfType<Bullet>();
        _bulletController._shootigSpeed = _speed;

        _bulletController._damageShop = _shopDamage;

        _damagePriceText.text = __damagePrice.ToString();
        _damageText.text = _shopDamage.ToString();
        


        _allMoney = PlayerPrefs.GetInt("SafeMoney", 0);
        _allMoneyText.text = _allMoney.ToString();
        
    }


    public void UpSpeed() 
    {
        if (_allMoney >= _speedPrice) 
        {
            _allMoney -= _speedPrice;

            _updateSpeedLevel++;
            _speedPrice = (int)(_speedPrice + ((_speedPrice * .25f) * _updateSpeedLevel));
            _speed = 1f / _updateSpeedLevel;

            _speedText.text = Mathf.Round(1 / _speed).ToString();
            _speedPriceText.text = _speedPrice.ToString();

            _allMoneyText.text = _allMoney.ToString();
            PlayerPrefs.SetInt("SpeedLevel", _updateSpeedLevel);
            PlayerPrefs.SetInt("UpdateSpeedPrice", _speedPrice);

            _bulletController._shootigSpeed = _speed;
        }
       
    }

    public void UpDamage() 
    {
        if (_allMoney >= __damagePrice) 
        {
            _allMoney -= __damagePrice;

            _updateDamageLevel++;
            __damagePrice = (int)(__damagePrice + ((__damagePrice * .25f) * _updateDamageLevel));
            _shopDamage = _updateDamageLevel;
            _bulletController._damageShop = _shopDamage;

            _damageText.text = _shopDamage.ToString();
            _damagePriceText.text = __damagePrice.ToString();

            _allMoneyText.text = _allMoney.ToString();
            PlayerPrefs.SetInt("DamageLevel", _updateDamageLevel);
            PlayerPrefs.SetInt("UpdateDamagePrice", __damagePrice);


        }
    }

    public float GetSpeed() { return _speed; }

    public void GetGameMoney(int amount) 
    {
        _allMoney += amount;
        _allMoneyText.text = _allMoney.ToString();
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("SafeMoney", _allMoney);
        PlayerPrefs.SetInt("UpdateSpeedPrice", _speedPrice);
        PlayerPrefs.SetInt("UpdateDamagePrice", __damagePrice);
        
    }


    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        _updateSpeedLevel = 4;
        _updateDamageLevel = 1;

        _speedPrice = PlayerPrefs.GetInt("UpdateSpeedPrice", 5);
        _speed = 1f / _updateSpeedLevel;

        _shopDamage = _updateDamageLevel;
        __damagePrice = PlayerPrefs.GetInt("UpdateDamagePrice", 8);



        _speedText.text = Mathf.Round(1 / _speed).ToString();
        _speedPriceText.text = _speedPrice.ToString();


        _bulletController = FindObjectOfType<Bullet>();
        _bulletController._shootigSpeed = _speed;

        _bulletController._damageShop = _shopDamage;

        _damagePriceText.text = __damagePrice.ToString();
        _damageText.text = _shopDamage.ToString();



        _allMoney = PlayerPrefs.GetInt("SafeMoney", 0);
        _allMoneyText.text = _allMoney.ToString();
    }






}
