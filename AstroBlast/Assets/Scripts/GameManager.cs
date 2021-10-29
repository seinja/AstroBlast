using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /* Не забыть увязать прогрессию уровня с колвом спавнящихся метеоритов
     * Связать с MeteoSpawner
     */


    // Описание UI и магазина
    [SerializeField] private TextMeshProUGUI _currentLevelText, _nextLevelText;
    [SerializeField] private Slider _levelProgression;
    [SerializeField] private GameObject _shopPanel;

    private Bank _bank;
    private CoinsGameUIController _coinsGameUIController;


    [SerializeField] private GameObject _progressionUI;
    private ShopController _shopController;



    // Описание игровых переменных
    [SerializeField] public static bool isGameOver;
    [SerializeField] public static bool isGameWin;
    public static GameManager Instance;
    private int _currentLevel;
    private int _nextLevel;
    private int _countOfMeteors;


    // Инициализация синглтона  и полей 
    private void Awake()
    {
        _bank = GetComponent<Bank>();
        _progressionUI.SetActive(true);
        _shopController = GetComponent<ShopController>();
        _coinsGameUIController = GetComponent<CoinsGameUIController>();

        if (Instance == null)
        {
            Instance = this;
        }

        isGameOver = false;
        isGameWin = false;

        _shopPanel.SetActive(false);

        // Инициализация полей UI
        LevelProgresBarInit();

        _countOfMeteors = _currentLevel * 3;

    }

    // Увеличение прогресса уровня.
    public void UpProgression()
    {
        _levelProgression.value++;
        if (_levelProgression.value >= _levelProgression.maxValue)
        {
            WinGame();

        }
    }

    // Конец игры и вывод магаза
    public void GameOver()
    {
        _progressionUI.SetActive(false);
        isGameOver = true;
        Time.timeScale = 0f;
        _shopPanel.SetActive(true);
        _bank.EndLevel();
        _coinsGameUIController.ClearCoinsUI();
    }

    // Конец игры и вывод магаза
    public void WinGame()
    {
        _progressionUI.SetActive(false);
        isGameWin = true;
        Time.timeScale = 0f;
        _shopPanel.SetActive(true);
        _currentLevel++;
        _bank.EndLevel();
        _coinsGameUIController.ClearCoinsUI();

    }

    // Возвращение в игру
    public void BackInGame()
    {
        _progressionUI.SetActive(true);
        isGameOver = false;
        isGameWin = false;
        ClearProgressBar();
        _shopPanel.SetActive(false);
        Time.timeScale = 1f;

        LevelProgresBarUpdate();
        _coinsGameUIController.ClearCoinsUI();

        _countOfMeteors = _currentLevel * 3;

        FindObjectOfType<MeteoSpawner>().RestartSpawn();
        FindObjectOfType<BulletController>().StopAllCoroutines();
        FindObjectOfType<BulletController>().ContinueShoot();

    }

    // Выход
    public void Quit()
    {
        Application.Quit();
    }

    // Отчистка UI
    private void ClearProgressBar()
    {
        LevelProgresBarUpdate();

        _countOfMeteors = _currentLevel * 3;
    }

    public int GetCurrentLevel() { return _currentLevel; }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        _currentLevel = 1;
        _currentLevelText.text = _currentLevel.ToString();
        _nextLevel = _currentLevel + 1;
        _nextLevelText.text = _nextLevel.ToString();
        _levelProgression.maxValue = _currentLevel * 3;
        _levelProgression.value = 0;

        _countOfMeteors = _currentLevel * 3;
    }

    public int GetMeteorsCount() { return _countOfMeteors; }


    private void LevelProgresBarInit() 
    {
        _currentLevel = PlayerPrefs.GetInt("GameLevel", 1);
        _currentLevelText.text = _currentLevel.ToString();
        _nextLevel = _currentLevel + 1;
        _nextLevelText.text = _nextLevel.ToString();
        _levelProgression.maxValue = _currentLevel * 3;
        _levelProgression.value = 0;
    }

    private void LevelProgresBarUpdate() 
    {
        _currentLevelText.text = _currentLevel.ToString();
        _nextLevel = _currentLevel + 1;
        _nextLevelText.text = _nextLevel.ToString();
        _levelProgression.maxValue = _currentLevel * 3;
        _levelProgression.value = 0;
    }

}
