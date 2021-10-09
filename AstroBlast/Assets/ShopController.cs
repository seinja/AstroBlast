using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _priceText, _speedText, _allMoneyText;

    private int _allMoney;

    private int _updateSpeedLevel;
    private float _speed;
    private int _price;

    private Bullet _bulletController;


    private void Awake()
    {
        _updateSpeedLevel = PlayerPrefs.GetInt("SpeedLevel", 4);
        _price = PlayerPrefs.GetInt("UpdatePrice", 5); 
        _speed = 1f / _updateSpeedLevel;
        Debug.Log("Speed : " + _speed);
        Debug.Log("Price : " + _price);
        Debug.Log("Update Level : " + _updateSpeedLevel);
        Debug.Log("Time scale : " + Time.timeScale);


        _speedText.text = Mathf.Round(1 / _speed).ToString();
        _priceText.text = _price.ToString();

        _bulletController = FindObjectOfType<Bullet>();
        _bulletController._shootigSpeed = _speed;


        _allMoney = PlayerPrefs.GetInt("SafeMoney", 0);
        _allMoneyText.text = _allMoney.ToString();
        
    }


    public void UpSpeed() 
    {
        if (_allMoney >= _price) 
        {
            _allMoney -= _price;

            _updateSpeedLevel++;
            _price = (int)(_price + ((_price * .25f) * _updateSpeedLevel));
            _speed = 1f / _updateSpeedLevel;


            Debug.Log("Speed : " + _speed);

            _speedText.text = Mathf.Round(1 / _speed).ToString();
            _priceText.text = _price.ToString();

            _allMoneyText.text = _allMoney.ToString();
            PlayerPrefs.SetInt("SpeedLevel", _updateSpeedLevel);
            PlayerPrefs.SetInt("UpdatePrice", _price);

            _bulletController._shootigSpeed = _speed;
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
        PlayerPrefs.SetInt("UpdatePrice", _price);
    }






}
