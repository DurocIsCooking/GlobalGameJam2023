using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    [Header("Exit")]
    [SerializeField] private GameObject m_Exit;

    [Header("Puzzles")]
    [SerializeField] private GameObject m_SafePuzzle;
    [SerializeField] private GameObject m_GlyphPuzzle;
    [SerializeField] private GameObject m_ClockPuzzle;
    [SerializeField] private GameObject m_PianoPuzzle;
    private GameObject m_CurrentPuzzle;

    [SerializeField] private bool m_DebugSafePuzzle;
    [SerializeField] private bool m_DebugGlyphPuzzle;
    [SerializeField] private bool m_DebugClockPuzzle;
    [SerializeField] private bool m_DebugPianoPuzzle;
    [SerializeField] private bool m_DebugOffSwitch;

    [Header("Start, End & Speed")]
    [SerializeField] private Transform m_OffScreen;
    [SerializeField] private Transform m_OnScreen;
    [SerializeField] private int m_Speed;
    private int m_SpeedMultiplier;
    [SerializeField] private bool m_MovePuzzleUp;
    [SerializeField] private bool m_MovePuzzleDown;
    

    //---SINGLETON---//

    private static PuzzleManager instance;

    public static PuzzleManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<PuzzleManager>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject();
                    singleton.AddComponent<PuzzleManager>();
                    singleton.name = "(Singleton) PuzzleManager";
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        m_Exit.SetActive(false);

        m_CurrentPuzzle = null;

        m_SpeedMultiplier = 100;

        GameObject canvas = m_OnScreen.transform.parent.parent.parent.gameObject;
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        m_OnScreen.position = new Vector3(canvasRect.rect.width/2, canvasRect.rect.height/2, 0) * canvasRect.localScale.x;
        m_OffScreen.position = m_OnScreen.position + new Vector3(0, -700, 0);
        m_Exit.GetComponent<RectTransform>().position = m_OnScreen.position + new Vector3(canvasRect.rect.width / 8, canvasRect.rect.height / 8, 0) * canvasRect.localScale.x;

        m_SafePuzzle.transform.position = m_OffScreen.position;
        m_GlyphPuzzle.transform.position = m_OffScreen.position;
        m_ClockPuzzle.transform.position = m_OffScreen.position;
        m_PianoPuzzle.transform.position = m_OffScreen.position;
    }

    private void Update()
    {
        if(m_DebugSafePuzzle)
        {
            PuzzleUp("Safe");
        }
        else if(m_DebugGlyphPuzzle)
        {
            PuzzleUp("Glyph");
        }
        else if(m_DebugClockPuzzle)
        {
            PuzzleUp("Clock");
        }
        else if(m_DebugPianoPuzzle)
        {
            PuzzleUp("Piano");
        }
        else if(m_DebugOffSwitch)
        {
            m_DebugSafePuzzle = false;
            m_DebugGlyphPuzzle = false;
            m_DebugClockPuzzle = false;
            m_DebugPianoPuzzle = false;
            PuzzleDown("Regular");
        }

        if (m_MovePuzzleUp)
        {
            m_CurrentPuzzle.transform.position = Vector3.MoveTowards(m_CurrentPuzzle.transform.position, m_OnScreen.position, m_Speed * m_SpeedMultiplier * Time.deltaTime);

            Vector3 roundedPosition = new Vector3(Mathf.Round(m_CurrentPuzzle.transform.position.x), Mathf.Round(m_CurrentPuzzle.transform.position.y), 0);

            if ((m_CurrentPuzzle.transform.position - m_OnScreen.position).magnitude <= 1)
            {
                m_Exit.SetActive(true);
                m_MovePuzzleUp = false;

                m_DebugSafePuzzle = false;
                m_DebugGlyphPuzzle = false;
                m_DebugClockPuzzle = false;
                m_DebugPianoPuzzle = false;
            }
        }

        if (m_MovePuzzleDown)
        {
            Debug.Log("send puzzle down");
            m_CurrentPuzzle.transform.position = Vector3.MoveTowards(m_CurrentPuzzle.transform.position, m_OffScreen.position, m_Speed * m_SpeedMultiplier * Time.deltaTime);

            Vector3 roundedPosition = new Vector3(Mathf.Round(m_CurrentPuzzle.transform.position.x), Mathf.Round(m_CurrentPuzzle.transform.position.y), 0);

            if ((m_CurrentPuzzle.transform.position - m_OffScreen.position).magnitude <= 1)
            {
                Debug.Log("Puzzle down complete");
                m_MovePuzzleDown = false;

                m_DebugOffSwitch = false;
            }
        }
    }

    public void PuzzleUp(string Puzzle)
    {
        switch (Puzzle)
        {
            case "Safe":
                m_CurrentPuzzle = m_SafePuzzle;
                break;
            case "Glyph":
                m_CurrentPuzzle = m_GlyphPuzzle;
                break;
            case "Clock":
                m_CurrentPuzzle = m_ClockPuzzle;
                break;
            case "Piano":
                m_CurrentPuzzle = m_PianoPuzzle;
                AudioManager.Instance.StopBGM();
                break;
        }

        
        m_MovePuzzleUp = true;
    }

    public void PuzzleDown(string Type)
    {
        GameManager.Instance.SwitchGameState(GameManager.GameStates.FreePlay);
        if (Type == "Regular")
        {
            m_MovePuzzleDown = true;
            AudioManager.Instance.PlayBGM();
        }
        else if(Type == "Final")
        {
            m_MovePuzzleDown = true;
        }

        m_Exit.SetActive(false);
    }
}
