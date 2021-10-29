using UnityEngine;
using TMPro;

public class CoinsGameUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI  _cuurentAmountOfCoinsText;

    private Bank _bank;

    private void Awake()
    {
        _bank = GetComponent<Bank>();
        _bank.OnCoinsValueChagedEvent += OnCoinsValueChange;

        _cuurentAmountOfCoinsText.text = null;

    }

    public void ClearCoinsUI() 
    {
        _cuurentAmountOfCoinsText.text = "0";
    }


    private void OnCoinsValueChange(object sender, int oldCoinsValue, int newCoinsValue)
    {
        _cuurentAmountOfCoinsText.text = newCoinsValue.ToString();
    }

   
}
