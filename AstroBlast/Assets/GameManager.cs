using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /* Не забыть увязать прогрессию уровня с колвом спавнящихся метеоритов
     * Связать с MeteoSpawner
     */




    // Описание UI и магазина
    [SerializeField] private TextMeshProUGUI _currentLevelText, _nextLevelText, _cuurentAmountOfCoinsText;
    [SerializeField] private Slider _levelProgression;
    [SerializeField] private GameObject _shopPanel;

    private ShopController _shopController;



    // Описание игровых переменных
    [SerializeField] public static bool isGameOver;
    [SerializeField] public static bool isGameWin;
    public static GameManager Instance;
    private int _currentLevel;
    private int _nextLevel;
    private int _cuurentAmountOfCoins = 0;


    // Инициализация синглтона  и полей 
    private void Awake()
    {
        _shopController = GetComponent<ShopController>();

        if (Instance == null) 
        {
            Instance = this;
        }

        isGameOver = false;
        isGameWin = false;

        _shopPanel.SetActive(false);

        // Инициализация полей UI
        _currentLevel = PlayerPrefs.GetInt("CuurentLevel", 1);
        _cuurentAmountOfCoinsText.text = _cuurentAmountOfCoins.ToString();
        _currentLevelText.text = _currentLevel.ToString();
        _nextLevel = _currentLevel + 1;
        _nextLevelText.text = _nextLevel.ToString();
        _levelProgression.maxValue = _currentLevel * 5;
        _levelProgression.value = 0;
        
    }

    // Увеличение прогресса уровня.
    public void UpProgression() 
    {
        _levelProgression.value++;
        if (_levelProgression.value == _levelProgression.maxValue) 
        {
            WinGame();
        }
    }

    // Конец игры и вывод магаза
    public void GameOver() 
    {
        isGameOver = true;
        Time.timeScale = 0f;
        _shopPanel.SetActive(true);
        _shopController.GetGameMoney(_cuurentAmountOfCoins);




    }
    // Конец игры и вывод магаза
    public void WinGame() 
    {
        isGameWin = true;
        Time.timeScale = 0f;
        _shopPanel.SetActive(true);
        _currentLevel++;
        PlayerPrefs.SetInt("CuurentLevel", _currentLevel);
        _shopController.GetGameMoney(_cuurentAmountOfCoins);

    }

    // Получение нынешней скорости стрельбы

    // Подбор монеты игроком и изменение UI
    public void PickUpCoin(int amount) 
    {
        _cuurentAmountOfCoins += amount;
        _cuurentAmountOfCoinsText.text = _cuurentAmountOfCoins.ToString();
    }

    // Возвращение в игру
    public void BackInGame() 
    {
        isGameOver = false;
        isGameWin = false;
        ClearProgressBar();
        _shopPanel.SetActive(false);
        Time.timeScale = 1f;
        _cuurentAmountOfCoins = 0;
        _cuurentAmountOfCoinsText.text = _cuurentAmountOfCoins.ToString();


        FindObjectOfType<MeteoSpawner>().StartSpawn();

    }

    // Выход
    public void Quit() 
    {
        Application.Quit();
    }


    // Отчистка UI
    private void ClearProgressBar() 
    {
        _currentLevelText.text = _currentLevel.ToString();
        _nextLevel = _currentLevel + 1;
        _nextLevelText.text = _nextLevel.ToString();
        _levelProgression.maxValue = _currentLevel * 5;
        _levelProgression.value = 0;
    }

    public int GetCurrentLevel() { return _currentLevel; }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("CuurentLevel", _currentLevel);
    }

}
