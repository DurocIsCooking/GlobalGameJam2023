using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used this tutorial for dialogue system: https://www.youtube.com/watch?v=_nRzoTzeyxU&ab_channel=Brackeys

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }
}
