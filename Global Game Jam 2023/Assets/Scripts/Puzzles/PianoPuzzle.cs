using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoPuzzle : MonoBehaviour
{
    //SOLUTION: 3 4 3 1 3 6 8 6 3 4

    [SerializeField] private int m_Solution1;
    private bool m_Solution1Check;

    [SerializeField] private int m_Solution2;
    private bool m_Solution2Check;

    [SerializeField] private int m_Solution3;
     private bool m_Solution3Check;

    [SerializeField] private int m_Solution4;
    private bool m_Solution4Check;

    [SerializeField] private int m_Solution5;
    private bool m_Solution5Check;

    [SerializeField] private int m_Solution6;
    private bool m_Solution6Check;

    [SerializeField] private int m_Solution7;
    private bool m_Solution7Check;

    [SerializeField] private int m_Solution8;
    private bool m_Solution8Check;

    [SerializeField] private int m_Solution9;
    private bool m_Solution9Check;

    [SerializeField] private int m_Solution10;
    private bool m_Solution10Check;

    private int m_DummyNumber = 0;
    private int m_Solution1Original;
    private int m_Solution2Original;
    private int m_Solution3Original;
    private int m_Solution4Original;
    private int m_Solution5Original;
    private int m_Solution6Original;
    private int m_Solution7Original;
    private int m_Solution8Original;
    private int m_Solution9Original;
    private int m_Solution10Original;

    //---SINGLETON---//

    private static PianoPuzzle instance;

    public static PianoPuzzle Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<PianoPuzzle>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject();
                    singleton.AddComponent<PianoPuzzle>();
                    singleton.name = "(Singleton) PianoPuzzle";
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
        m_Solution1Original = m_Solution1;
        m_Solution2Original = m_Solution2;
        m_Solution3Original = m_Solution3;
        m_Solution4Original = m_Solution4;
        m_Solution5Original = m_Solution5;
        m_Solution6Original = m_Solution6;
        m_Solution7Original = m_Solution7;
        m_Solution8Original = m_Solution8;
        m_Solution9Original = m_Solution9;
        m_Solution10Original = m_Solution10;
    }

    public void CheckSolution(int Key)
    {
        if (Key == m_Solution1 || Key == m_Solution1Original && m_Solution2Check == false)
        {
            m_Solution1Check = true;
            m_Solution1 = m_DummyNumber;
        }
        else if (Key == m_Solution2 && m_Solution1Check == true && m_Solution3Check == false)
        {
            m_Solution2Check = true;
            m_Solution2 = m_DummyNumber;
        }
        else if (Key == m_Solution3 && m_Solution2Check == true && m_Solution3Check == false)
        {
            m_Solution3Check = true;
            m_Solution3 = m_DummyNumber;
        }
        else if (Key == m_Solution4 && m_Solution3Check == true && m_Solution5Check == false)
        {
            m_Solution4Check = true;
            m_Solution4 = m_DummyNumber;
        }
        else if (Key == m_Solution5 && m_Solution4Check == true && m_Solution6Check == false)
        {
            m_Solution5Check = true;
            m_Solution5 = m_DummyNumber;
        }
        else if (Key == m_Solution6 && m_Solution5Check == true && m_Solution7Check == false)
        {
            m_Solution6Check = true;
            m_Solution6 = m_DummyNumber;
        }
        else if (Key == m_Solution7 && m_Solution6Check == true && m_Solution8Check == false)
        {
            m_Solution7Check = true;
            m_Solution7 = m_DummyNumber;
        }
        else if (Key == m_Solution8 && m_Solution7Check == true && m_Solution9Check == false)
        {
            m_Solution8Check = true;
            m_Solution8 = m_DummyNumber;
        }
        else if (Key == m_Solution9 && m_Solution8Check == true && m_Solution10Check == false)
        {
            m_Solution9Check = true;
            m_Solution9 = m_DummyNumber;
        }
        else if (Key == m_Solution10 && m_Solution9Check == true)
        {
            m_Solution10Check = true;
            m_Solution10 = m_DummyNumber;

            // Song starts playing automatically after 2s
            // Grandma dialogue
            // Fade to black
            // Credits

            Debug.Log("You did it!");
            PuzzleManager.Instance.PuzzleDown("Final");
            AudioManager.Instance.PianoPuzzleSolve();
            ResetPuzzle();
            StartCoroutine(GameManager.Instance.GameEnd());
        }
        else
        {
            ResetPuzzle();
        }
    }

    public void ResetPuzzle()
    {
        m_Solution1Check = false;
        m_Solution1 = m_Solution1Original;

        m_Solution2Check = false;
        m_Solution2 = m_Solution2Original;

        m_Solution3Check = false;
        m_Solution3 = m_Solution3Original;

        m_Solution4Check = false;
        m_Solution4 = m_Solution4Original;

        m_Solution5Check = false;
        m_Solution5 = m_Solution5Original;

        m_Solution6Check = false;
        m_Solution6 = m_Solution6Original;

        m_Solution7Check = false;
        m_Solution7 = m_Solution7Original;

        m_Solution8Check = false;
        m_Solution8 = m_Solution8Original;

        m_Solution9Check = false;
        m_Solution9 = m_Solution9Original;

        m_Solution10Check = false;
        m_Solution10 = m_Solution10Original;
    }
}
