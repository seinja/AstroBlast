using UnityEngine;
public class Bank : MonoBehaviour
{
    public delegate void BankHandler(object sender, int oldCoinsValue, int newCoinsValue);
    public event BankHandler OnCoinsValueChagedEvent;

    public int coins { get; private set; }
    public int gameCoins { get; private set; }

    private void Awake()
    {
        coins = PlayerPrefs.GetInt("SafeCoins", 0);
    }

    public void AddCoins(object sender, int amount) 
    {
        var oldCoinsValue = this.gameCoins;
        this.gameCoins += amount;

        this.OnCoinsValueChagedEvent?.Invoke(sender,oldCoinsValue,this.gameCoins);
    }

    public void SpendCoins(object sender, int amount) 
    {
        var oldCoinsValue = this.coins;
        this.coins -= amount;

        this.OnCoinsValueChagedEvent?.Invoke(sender, oldCoinsValue, this.coins);
    }

    public void EndLevel() 
    {
        EndLevelSafeCoins();
    }


    public bool IsEnoughCoins(int amount) 
    {
        return amount <= coins;
    }

    public void EndLevelSafeCoins() 
    {
        this.coins += gameCoins;
        this.OnCoinsValueChagedEvent?.Invoke(this, 0, this.coins);
    }

    public int GetGameCoins => gameCoins;

    public int GetCoins => coins;



}
