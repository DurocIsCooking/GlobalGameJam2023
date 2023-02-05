using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CypherPuzzle : MonoBehaviour
{
    public GameObject IncorrectMessage;
    public TextMeshProUGUI InputText;

    public InputField m_InputText;
    public string m_Text;
    public string m_Answer;

    private void Awake()
    {
        IncorrectMessage.SetActive(false);
        m_Text = m_InputText.text;
    }


    private void Update()
    {
        if(m_InputText.text != "Kettle" || m_InputText.text != "")
        {
            IncorrectMessage.SetActive(true);

            Debug.Log("That's the wrong word!");
        }
        else
        {
            IncorrectMessage.SetActive(false);
            Debug.Log("You did it!");
        }
    }
}
