using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOptionsHandler : MonoBehaviour
{
    [SerializeField] private bool m_GamePaused;
    [SerializeField] private GameObject m_PauseScreen;

    //---SINGLETON---//

    private static PauseOptionsHandler instance;

    public static PauseOptionsHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<PauseOptionsHandler>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject();
                    singleton.AddComponent<PauseOptionsHandler>();
                    singleton.name = "(Singleton) PauseOptionsHandler";
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
        m_GamePaused = false;
        m_PauseScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (m_GamePaused)
            {
                Pause("Start");
            }
            else
            {
                Pause("Stop");
            }
        }
    }

    private void Pause(string State)
    {
        if(State == "Start")
        {
            m_GamePaused = true;
            m_PauseScreen.SetActive(false);
            Debug.Log("Unpause");
        }
        else
        {
            m_GamePaused = false;
            m_PauseScreen.SetActive(true);
            Debug.Log("Pause");
        }
    }
}
