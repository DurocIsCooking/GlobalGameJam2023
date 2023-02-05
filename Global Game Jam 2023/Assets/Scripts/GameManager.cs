using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public DialogueTrigger GameEndDialogue;
    public DialogueTrigger TimeTravelDialogue;
    private bool _firstTimeTravel = true;

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
        AudioManager.Instance.PlaySFX("Time Travel");
        PresentCamera.enabled = !PresentCamera.enabled;
        PastCamera.enabled = !PastCamera.enabled;
        SwitchGameState(GameStates.FreePlay);
        if (_firstTimeTravel)
        {
            _firstTimeTravel = false;
            TimeTravelDialogue.TriggerDialogue();
        }
    }

    public IEnumerator GameEnd()
    {
        SwitchGameState(GameStates.Cutscene);
        yield return new WaitForSeconds(5);
        // Trigger grandma's dialogue;
        GameEndDialogue.TriggerDialogue();
        yield return new WaitUntil(FinalDialogueComplete);
        SwitchGameState(GameStates.Cutscene);
        yield return new WaitForSeconds(2);
        FadeToBlack.gameObject.SetActive(true);
        FadeToBlack.gameObject.transform.SetAsLastSibling();
        while (FadeToBlack.color.a < 1)
        {
            Color tempColor = FadeToBlack.color;
            tempColor.a += 0.025f;
            FadeToBlack.color = tempColor;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Start Menu");
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
