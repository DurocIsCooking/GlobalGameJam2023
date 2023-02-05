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
        Color tempColor = FadeToBlack.color;
        tempColor.a = 0;
        FadeToBlack.color = tempColor;
        FadeToBlack.gameObject.SetActive(false);
    }

    public Camera PresentCamera;
    public Camera PastCamera;
    public Image FadeToBlack;
    

    public enum GameStates
    { 
        FreePlay,
        Dialogue,
        UsingItem,
        PopUp,
        Puzzle,
        Cutscene
    }

    public GameStates CurrentGameState;

    public void SwitchGameState(GameStates newGameState)
    {
        if (newGameState == GameStates.Dialogue && InventoryManager.Instance.ItemInUse != null)
        {
            InventoryManager.Instance.ItemInUse.StopUsingItem();
        }
        Debug.Log("Game state: " + newGameState.ToString());
        CurrentGameState = newGameState;
    }

    public void TimeTravel()
    {
        PresentCamera.enabled = !PresentCamera.enabled;
        PastCamera.enabled = !PastCamera.enabled;
        SwitchGameState(GameStates.FreePlay);
    }

    public IEnumerator GameEnd()
    {
        SwitchGameState(GameStates.Cutscene);
        yield return new WaitForSeconds(5);
        // Trigger grandma's dialogue;
        gameObject.transform.GetChild(0).GetComponent<DialogueTrigger>().TriggerDialogue();
        yield return new WaitUntil(FinalDialogueComplete);
        SwitchGameState(GameStates.Cutscene);
        yield return new WaitForSeconds(2);
        FadeToBlack.gameObject.SetActive(true);
        FadeToBlack.gameObject.transform.SetAsLastSibling();
        while (FadeToBlack.color.a < 1)
        {
            Color tempColor = FadeToBlack.color;
            tempColor.a += 0.05f;
            FadeToBlack.color = tempColor;
            yield return new WaitForSeconds(0.2f);
        }
        Debug.Log("Roll credits");
        yield break;
    }

    public bool FinalDialogueComplete()
    {
        if (CurrentGameState != GameStates.Dialogue)
        {
            return true;
        }
        else return false;
    }
}
