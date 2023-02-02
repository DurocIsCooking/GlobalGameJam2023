using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton pattern
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        CurrentGameState = GameStates.FreePlay;
    }


    public enum GameStates
    { 
        FreePlay,
        Dialogue,
        UsingItem
    }

    public GameStates CurrentGameState;



    public void GrowTree()
    {
        // Grow tree
        Debug.Log("Grow tree!");
    }    
}
