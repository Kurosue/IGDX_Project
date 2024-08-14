using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GSGameManager : MonoBehaviour
{
    private int _currentLevel;
    private int _levelCode;
    private List<int> _levelsAccomplished;

    void Awake() 
    {
        DontDestroyOnLoad(this.gameObject);
        _levelsAccomplished = new List<int>(); // Initialize the list
    }

    void Start()
    {
        // Any necessary initialization can go here
    }

    

    void FinishLevel() 
    {
        _currentLevel += 1;
        _levelCode = DetermineNextLevel();
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

