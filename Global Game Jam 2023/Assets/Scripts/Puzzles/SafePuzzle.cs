using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafePuzzle : MonoBehaviour
{
    [SerializeField] private Text m_Button1;
    [SerializeField] private Text m_Button2;
    [SerializeField] private Text m_Button3;
    [SerializeField] private Text m_Button4;

    private int m_Button1Value; 
    private int m_Button2Value;
    private int m_Button3Value;
    private int m_Button4Value;

    [SerializeField] private int m_Button1Solution;
    [SerializeField] private int m_Button2Solution;
    [SerializeField] private int m_Button3Solution;
    [SerializeField] private int m_Button4Solution;

    public void Start()
    {
        m_Button1.text = "0";
        m_Button2.text = "0";
        m_Button3.text = "0";
        m_Button4.text = "0";

        m_Button1Value = 0;
        m_Button2Value = 0;
        m_Button3Value = 0;
        m_Button4Value = 0;
    }

    public void Dial(int Button)
    {
        if (Button == 1)
        {
            switch (m_Button1Value)
            {
                case 0:
                    m_Button1.text = "1";
                    m_Button1Value = 1;
                    break;
                case 1:
                    m_Button1.text = "2";
                    m_Button1Value = 2;
                    break;
                case 2:
                    m_Button1.text = "3";
                    m_Button1Value = 3;
                    break;
                case 3:
                    m_Button1.text = "4";
                    m_Button1Value = 4;
                    break;
                case 4:
                    m_Button1.text = "5";
                    m_Button1Value = 5;
                    break;
                case 5:
                    m_Button1.text = "6";
                    m_Button1Value = 6;
                    break;
                case 6:
                    m_Button1.text = "7";
                    m_Button1Value = 7;
                    break;
                case 7:
                    m_Button1.text = "8";
                    m_Button1Value = 8;
                    break;
                case 8:
                    m_Button1.text = "9";
                    m_Button1Value = 9;
                    break;
                case 9:
                    m_Button1.text = "0";
                    m_Button1Value = 0;
                    break;
            }
        }
        else if(Button == 2)
        {
            switch (m_Button2Value)
            {
                case 0:
                    m_Button2.text = "1";
                    m_Button2Value = 1;
                    break;
                case 1:
                    m_Button2.text = "2";
                    m_Button2Value = 2;
                    break;
                case 2:
                    m_Button2.text = "3";
                    m_Button2Value = 3;
                    break;
                case 3:
                    m_Button2.text = "4";
                    m_Button2Value = 4;
                    break;
                case 4:
                    m_Button2.text = "5";
                    m_Button2Value = 5;
                    break;
                case 5:
                    m_Button2.text = "6";
                    m_Button2Value = 6;
                    break;
                case 6:
                    m_Button2.text = "7";
                    m_Button2Value = 7;
                    break;
                case 7:
                    m_Button2.text = "8";
                    m_Button2Value = 8;
                    break;
                case 8:
                    m_Button2.text = "9";
                    m_Button2Value = 9;
                    break;
                case 9:
                    m_Button2.text = "0";
                    m_Button2Value = 0;
                    break;
            }
        }
        else if(Button == 3)
        {
            switch (m_Button3Value)
            {
                case 0:
                    m_Button3.text = "1";
                    m_Button3Value = 1;
                    break;
                case 1:
                    m_Button3.text = "2";
                    m_Button3Value = 2;
                    break;
                case 2:
                    m_Button3.text = "3";
                    m_Button3Value = 3;
                    break;
                case 3:
                    m_Button3.text = "4";
                    m_Button3Value = 4;
                    break;
                case 4:
                    m_Button3.text = "5";
                    m_Button3Value = 5;
                    break;
                case 5:
                    m_Button3.text = "6";
                    m_Button3Value = 6;
                    break;
                case 6:
                    m_Button3.text = "7";
                    m_Button3Value = 7;
                    break;
                case 7:
                    m_Button3.text = "8";
                    m_Button3Value = 8;
                    break;
                case 8:
                    m_Button3.text = "9";
                    m_Button3Value = 9;
                    break;
                case 9:
                    m_Button3.text = "0";
                    m_Button3Value = 0;
                    break;
            }
        }
        else if(Button == 4)
        {
            switch (m_Button4Value)
            {
                case 0:
                    m_Button4.text = "1";
                    m_Button4Value = 1;
                    break;
                case 1:
                    m_Button4.text = "2";
                    m_Button4Value = 2;
                    break;
                case 2:
                    m_Button4.text = "3";
                    m_Button4Value = 3;
                    break;
                case 3:
                    m_Button4.text = "4";
                    m_Button4Value = 4;
                    break;
                case 4:
                    m_Button4.text = "5";
                    m_Button4Value = 5;
                    break;
                case 5:
                    m_Button4.text = "6";
                    m_Button4Value = 6;
                    break;
                case 6:
                    m_Button4.text = "7";
                    m_Button4Value = 7;
                    break;
                case 7:
                    m_Button4.text = "8";
                    m_Button4Value = 8;
                    break;
                case 8:
                    m_Button4.text = "9";
                    m_Button4Value = 9;
                    break;
                case 9:
                    m_Button4.text = "0";
                    m_Button4Value = 0;
                    break;
            }
        }

        SafeSolution();
    }

    public void SafeSolution()
    {
        if(m_Button1Value == m_Button1Solution && m_Button2Value == m_Button2Solution && m_Button3Value == m_Button3Solution && m_Button4Value == m_Button4Solution)
        {
            Debug.Log("You did it!");
        }
    }
}
