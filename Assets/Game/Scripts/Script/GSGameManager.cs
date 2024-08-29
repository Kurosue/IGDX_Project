using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSGameManager : MonoBehaviour
{
    public GameObject currencyPrefab;
    public GameObject hpPrefab;
    public GameObject soulPickupPrefab;
    public Transform rewardSpawnPoint;
    private GameObject _soulReward;
    private int _currentLevel;
    private int _levelCode;
    private List<int> _levelsAccomplished;
    private int _enemiesLeft;
    private string _reward;
    private int enemiesCount = 3;
    private int currency = 0;
    public static event Action OnLevelCleared;
    public string folderPath = "Prefabs";

    void Awake() 
    {
        DontDestroyOnLoad(this.gameObject);
        _levelsAccomplished = new List<int>(); // Initialize the list
        StartLevel();
    }

    void OnEnable()
    {
        Enemy.OnEnemyKilled += HandleEnemyKilled;
        SoulPickup.OnRewardPickedUp += CreateDoors;
        MoneyPickup.OnRewardPickedUp += CreateDoors;
        HealthPickup.OnRewardPickedUp += CreateDoors;
        MoneyPickup.OnMoneyPickedUp += IncreaseMoney;
    }

    void OnDisable()
    {
        Enemy.OnEnemyKilled -= HandleEnemyKilled;
        SoulPickup.OnRewardPickedUp -= CreateDoors;
        MoneyPickup.OnRewardPickedUp -= CreateDoors;
        HealthPickup.OnRewardPickedUp -= CreateDoors;
        MoneyPickup.OnMoneyPickedUp -= IncreaseMoney;
    }

    void StartLevel()
    {
        _enemiesLeft = enemiesCount; // Initialize enemies left at the start of the level
    }

    void HandleEnemyKilled()
    {
        _enemiesLeft--;
        Debug.Log(_enemiesLeft);

        if (_enemiesLeft <= 0)
        {
            LevelCleared();
        }
    }

    void LevelCleared() 
    {
        SpawnReward();
        OnLevelCleared?.Invoke();
    }

    void CreateDoors()
    {
        
    }

    void SpawnReward() 
    {
        GameObject rewardPrefab = null;

        if (_reward == "Currency") 
        {
            rewardPrefab = currencyPrefab;
            Instantiate(currencyPrefab, rewardSpawnPoint.position, rewardSpawnPoint.rotation);
        }
        else if (_reward == "HP") 
        {
            rewardPrefab = hpPrefab;
            Instantiate(hpPrefab, rewardSpawnPoint.position, rewardSpawnPoint.rotation);
        }
        else if (_reward == "Soul") 
        {
            _soulReward = Instantiate(soulPickupPrefab, rewardSpawnPoint.position, rewardSpawnPoint.rotation);
            _soulReward.GetComponent<SoulPickup>().soul = selectSoul();

        }
    }

    Soul selectSoul() 
    {
        Soul[] soulList = Resources.LoadAll<Soul>(folderPath);
        Soul selectedSoul = soulList[UnityEngine.Random.Range(0, soulList.Length)];
        return selectedSoul;
    }

    void IncreaseMoney()
    {
        currency += 5;
    }

    void FinishLevel() 
    {
        _currentLevel = DetermineNextLevel();
        // Load the next level logic
    }

    int DetermineNextLevel()
    {
        int number = 0;

        if (_currentLevel >= 1 && _currentLevel <= 3)
        {
            do
            {
                number = UnityEngine.Random.Range(1, 6); // Random number between 1 and 5
            }
            while (_levelsAccomplished.Contains(number)); // Check if the number is already in _levelsAccomplished
        }
        else if (_currentLevel == 4)
        {
            number = 16;
        }
        else if (_currentLevel >= 5 && _currentLevel <= 7)
        {
            do
            {
                number = UnityEngine.Random.Range(6, 11); // Random number between 6 and 10
            }
            while (_levelsAccomplished.Contains(number));
        }
        else if (_currentLevel == 8)
        {
            number = 17;
        }
        else if (_currentLevel >= 9 && _currentLevel <= 11)
        {
            do
            {
                number = UnityEngine.Random.Range(9, 12); // Random number between 9 and 11
            }
            while (_levelsAccomplished.Contains(number));
        }
        else
        {
            number = 18;
        }

        return number;
    }
}