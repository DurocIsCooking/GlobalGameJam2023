using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlyphPuzzle : MonoBehaviour
{
    [Header("Dials")]
    [SerializeField] private Button m_Dial1;
    [SerializeField] private Button m_Dial2;
    [SerializeField] private Button m_Dial3;

    [Header("Dial 1 Glyphs")]
    [SerializeField] private Sprite m_Glyph1;
    [SerializeField] private Sprite m_Glyph2;
    [SerializeField] private Sprite m_Glyph3;
    [SerializeField] private Sprite m_Glyph4;
    [Header("Dial 2 Glyphs")]
    [SerializeField] private Sprite m_Glyph5;
    [SerializeField] private Sprite m_Glyph6;
    [SerializeField] private Sprite m_Glyph7;
    [SerializeField] private Sprite m_Glyph8;
    [Header("Dial 3 Glyphs")]
    [SerializeField] private Sprite m_Glyph9;
    [SerializeField] private Sprite m_Glyph10;
    [SerializeField] private Sprite m_Glyph11;
    [SerializeField] private Sprite m_Glyph12;

    private int m_Dial1Value;
    private int m_Dial2Value;
    private int m_Dial3Value;

    private int m_Dial1Solution;
    private int m_Dial2Solution;
    private int m_Dial3Solution;

    [Header("Object References")]
    [SerializeField] private GameObject m_ClockGameObject;
    [SerializeField] private GameObject m_GlyphSolutionTriggers;
    public ItemGameObject MusicSheet2;
    public DialogueTrigger IncorrectInput;

    public void Start()
    {
        m_Dial1.GetComponent<Image>().sprite = m_Glyph1;
        m_Dial2.GetComponent<Image>().sprite = m_Glyph5;
        m_Dial3.GetComponent<Image>().sprite = m_Glyph9;

        m_Dial1Value = 1;
        m_Dial2Value = 2;
        m_Dial3Value = 3;

        m_Dial1Solution = 3;
        m_Dial2Solution = 2;
        m_Dial3Solution = 4;
    }

    public void Dial(int Button)
    {
        if(Button == 1)
        {
            switch (m_Dial1Value)
            {
                case 1:
                    m_Dial1.GetComponent<Image>().sprite = m_Glyph2;
                    m_Dial1Value = 2;
                    break;
                case 2:
                    m_Dial1.GetComponent<Image>().sprite = m_Glyph3;
                    m_Dial1Value = 3;
                    break;
                case 3:
                    m_Dial1.GetComponent<Image>().sprite = m_Glyph4;
                    m_Dial1Value = 4;
                    break;
                case 4:
                    m_Dial1.GetComponent<Image>().sprite = m_Glyph1;
                    m_Dial1Value = 1;
                    break;
            }
        }
        else if (Button == 2)
        {
            switch (m_Dial2Value)
            {
                case 1:
                    m_Dial2.GetComponent<Image>().sprite = m_Glyph6;
                    m_Dial2Value = 2;
                    break;
                case 2:
                    m_Dial2.GetComponent<Image>().sprite = m_Glyph7;
                    m_Dial2Value = 3;
                    break;
                case 3:
                    m_Dial2.GetComponent<Image>().sprite = m_Glyph8;
                    m_Dial2Value = 4;
                    break;
                case 4:
                    m_Dial2.GetComponent<Image>().sprite = m_Glyph5;
                    m_Dial2Value = 1;
                    break;
            }
        }
        else if (Button == 3)
        {
            switch (m_Dial3Value)
            {
                case 1:
                    m_Dial3.GetComponent<Image>().sprite = m_Glyph10;
                    m_Dial3Value = 2;
                    break;
                case 2:
                    m_Dial3.GetComponent<Image>().sprite = m_Glyph11;
                    m_Dial3Value = 3;
                    break;
                case 3:
                    m_Dial3.GetComponent<Image>().sprite = m_Glyph12;
                    m_Dial3Value = 4;
                    break;
                case 4:
                    m_Dial3.GetComponent<Image>().sprite = m_Glyph9;
                    m_Dial3Value = 1;
                    break;
            }
        }

        //GlyphSolution();
    }

    public void GlyphSolution()
    {
        if(m_Dial1Value == m_Dial1Solution && m_Dial2Value == m_Dial2Solution && m_Dial3Value == m_Dial3Solution)
        {
            // Add items
            InventoryManager.Instance.AddItem(MusicSheet2.Item);
            PianoPuzzle.Instance.ScoreFound(2);
            // Switch safe triggers
            m_ClockGameObject.transform.GetChild(0).gameObject.SetActive(false);
            m_ClockGameObject.transform.GetChild(1).gameObject.SetActive(true);
            // Banish puzzle
            PuzzleManager.Instance.PuzzleDown("Regular");
            // Trigger dialogue
            m_GlyphSolutionTriggers.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        else
        {
            IncorrectInput.TriggerDialogue();
            Debug.Log("REPRIMAND: INCORRECT INPUT, MEATBAG.");
        }
    }
}