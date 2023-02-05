using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentPot : MonoBehaviour
{

    public GameObject SeedTrigger;
    public GameObject DefaultTrigger;
    // A shallow but perverse spaghetti
    public void ChooseDialogue()
    {
        if(GameManager.Instance.CurrentGameState == GameManager.GameStates.UsingItem)
        {
            SeedTrigger.GetComponent<OnClickEvent>().OnClick();
        }
        else
        {
            DefaultTrigger.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
    }
}
