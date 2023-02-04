using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockPuzzle : MonoBehaviour
{
    [SerializeField] private Transform m_Hour;
    private int m_HourValue;
    [SerializeField] private Transform m_Minute;
    private int m_MinuteValue;

    [SerializeField] private int m_HourSolution;
    [SerializeField] private int m_MinuteSolution;

    public void Start()
    {
        m_HourValue = 12;
        m_MinuteValue = 12;

        /*
        m_HourRotation = new Vector3(0, 0, 0);
        m_Hour.rotation = Quaternion.Euler(m_HourRotation);

        m_MinuteRotation = new Vector3(0, 0, 0);
        m_Minute.rotation = Quaternion.Euler(m_MinuteRotation);
        */
    }

    public void RotateHour()
    {
        m_Hour.transform.Rotate(0, 0, -30);
        CheckClock("Hour");
    }

    public void RotateMinute()
    {
        m_Minute.transform.Rotate(0, 0, -30);
        CheckClock("Minute");
    }

    public void CheckClock(string Hand)
    {
        if(Hand == "Hour")
        {
            switch (m_HourValue)
            {
                case 1:
                    m_HourValue = 2;
                    break;
                case 2:
                    m_HourValue = 3;
                    break;
                case 3:
                    m_HourValue = 4;
                    break;
                case 4:
                    m_HourValue = 5;
                    break;
                case 5:
                    m_HourValue = 6;
                    break;
                case 6:
                    m_HourValue = 7;
                    break;
                case 7:
                    m_HourValue = 8;
                    break;
                case 8:
                    m_HourValue = 9;
                    break;
                case 9:
                    m_HourValue = 10;
                    break;
                case 10:
                    m_HourValue = 11;
                    break;
                case 11:
                    m_HourValue = 12;
                    break;
                case 12:
                    m_HourValue = 1;
                    break;
            }
        }
        else if(Hand == "Minute")
        {
            switch (m_MinuteValue)
            {
                case 1:
                    m_MinuteValue = 2;
                    break;
                case 2:
                    m_MinuteValue = 3;
                    break;
                case 3:
                    m_MinuteValue = 4;
                    break;
                case 4:
                    m_MinuteValue = 5;
                    break;
                case 5:
                    m_MinuteValue = 6;
                    break;
                case 6:
                    m_MinuteValue = 7;
                    break;
                case 7:
                    m_MinuteValue = 8;
                    break;
                case 8:
                    m_MinuteValue = 9;
                    break;
                case 9:
                    m_MinuteValue = 10;
                    break;
                case 10:
                    m_MinuteValue = 11;
                    break;
                case 11:
                    m_MinuteValue = 12;
                    break;
                case 12:
                    m_MinuteValue = 1;
                    break;
            }
        }

        ClockSolution();
    }

    public void ClockSolution()
    {
        if(m_HourValue == m_HourSolution && m_MinuteValue == m_MinuteSolution)
        {
            PuzzleManager.Instance.PuzzleDown("Regular");
            Debug.Log("You did it!");
        }
    }
}
