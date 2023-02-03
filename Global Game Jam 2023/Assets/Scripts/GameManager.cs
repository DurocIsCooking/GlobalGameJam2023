using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        PresentCamera.enabled = true;
        PastCamera.enabled = false;
    }

    public Camera PresentCamera;
    public Camera PastCamera;

    

    public enum GameStates
    { 
        FreePlay,
        Dialogue,
        UsingItem,
        PopUp
    }

    public GameStates CurrentGameState;

    public void SwitchGameState(GameStates newGameState)
    {
        Debug.Log("Game state: " + newGameState.ToString());
        CurrentGameState = newGameState;
    }

    public void TimeTravel()
    {
        PresentCamera.enabled = !PresentCamera.enabled;
        PastCamera.enabled = !PastCamera.enabled;
    }

}
