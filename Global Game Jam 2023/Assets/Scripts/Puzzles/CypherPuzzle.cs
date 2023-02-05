using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CypherPuzzle : MonoBehaviour
{
    public GameObject IncorrectMessage;
    public TextMeshProUGUI InputText;

    private void Awake()
    {
        IncorrectMessage.SetActive(false);
    }


    private void Update()
    {
        if(InputText.text != "Kettle" && InputText.text != "")
        {
            IncorrectMessage.SetActive(true);
        }
        else
        {
            IncorrectMessage.SetActive(false);
        }


    }
}
