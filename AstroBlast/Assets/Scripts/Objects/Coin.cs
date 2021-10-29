using UnityEngine;

public class Coin : MonoBehaviour
{
    
    private int _amount;
    private Bank _bank;
    private Vector3 _targetPosition = new Vector3(0,0,0);
    private void Start()
    {
        _bank = FindObjectOfType<Bank>();
        _amount = Random.Range(1, GameManager.Instance.GetCurrentLevel() * 6);
    }

    private void Update()
    {

        transform.Translate((_targetPosition - transform.position).normalized * 25f * Time.deltaTime);

        if (GameManager.isGameWin || GameManager.isGameOver)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AddCoinsInToBank();
            Destroy(this.gameObject);
        }
    }

    public void AddCoinsInToBank() 
    {
        _bank.AddCoins(this,_amount);
    }



}
