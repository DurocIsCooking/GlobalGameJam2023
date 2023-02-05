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

    private void Awake()
    {
        IncorrectMessage.SetActive(false);
    }


    private void Update()
    {
        /*
        if(InputText.text != "Kettle" && InputText.text != "")
        {
            IncorrectMessage.SetActive(true);
            Debug.Log("That's the wrong word!");
        }
        else
        {
            IncorrectMessage.SetActive(false);
            Debug.Log("You did it!");
        }
        */
    }

    public void CheckInput()
    {
        if(m_Input.text == m_Solution)
        {
            IncorrectMessage.SetActive(false);
            Debug.Log("You did it!");
            PuzzleManager.Instance.PuzzleDown("Regular");
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
