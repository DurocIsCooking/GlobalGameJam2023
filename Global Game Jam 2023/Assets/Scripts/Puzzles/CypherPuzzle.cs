using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class CypherPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject IncorrectMessage;
    //public TextMeshProUGUI InputText;
    [SerializeField] private Text m_Input;
    [SerializeField] private InputField m_InputField;
    [SerializeField] private string m_Solution;
    [SerializeField] private GameObject m_CypherSolutionTriggers;

    private void Awake()
    {
        IncorrectMessage.SetActive(false);
    }

    public void CheckInput()
    {
        if(m_Input.text.ToLower() == m_Solution.ToLower())
        {
            IncorrectMessage.SetActive(false);
            Debug.Log("You did it!");
            PuzzleManager.Instance.PuzzleDown("Regular");
            InventoryManager.Instance.ItemInUse.Item.PuzzleName = ""; // So that puzzle no longer opens
            m_CypherSolutionTriggers.GetComponent<DialogueTrigger>().TriggerDialogue();
            // trigger dialogue
        }
        else
        {
            IncorrectMessage.SetActive(true);
            m_InputField.text = "";
            m_InputField.ActivateInputField();
            Debug.Log("Hmm...");
        }
    }
}
