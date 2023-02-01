using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoPuzzle : MonoBehaviour
{
    [SerializeField] private int m_Solution1;
    [SerializeField] private bool m_Solution1Check;
    [SerializeField] private int m_Solution2;
    [SerializeField] private bool m_Solution2Check;
    [SerializeField] private int m_Solution3;
    [SerializeField] private bool m_Solution3Check;

    [SerializeField] private int[] m_Solutions; //If I use a list, how do I keep track of the Solutions Original values (if I intend on keeping the Dummy Value)?
    [SerializeField] private bool[] m_SolutionsCheck;
    private int[] m_SolutionsOrigin;

    private int m_DummyNumber = 0;
    private int m_Solution1Original;
    private int m_Solution2Original;
    private int m_Solution3Original;

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
    }

    public void CheckSolution(int Key)
    {
        if (Key == m_Solution1 && m_Solution2Check == false && m_Solution3Check == false)
        {
            m_Solution1Check = true;
            m_Solution1 = m_DummyNumber;
            //Needs review. Clicking on the correct note multiple times at the beginning should not "toggle" the sequence of notes. 
        }
        else if (Key == m_Solution2 && m_Solution1Check == true && m_Solution2Check == false && m_Solution3Check == false)
        {
            m_Solution2Check = true;
            m_Solution2 = m_DummyNumber;
        }
        else if (Key == m_Solution3 && m_Solution1Check == true && m_Solution2Check == true && m_Solution3Check == false)
        {
            m_Solution3Check = true;
            m_Solution3 = m_DummyNumber;
            Debug.Log("You did it!");

            ResetPuzzle();
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
    }
}
