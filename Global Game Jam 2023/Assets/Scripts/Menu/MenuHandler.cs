using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject m_StartMenu;
    [SerializeField] private GameObject m_OptionsMenu;
    [SerializeField] private GameObject m_Credits;
    private GameObject m_CurrentMenu;

    public void Start()
    {
        m_StartMenu.SetActive(true);
        m_OptionsMenu.SetActive(false);
        m_Credits.SetActive(false);

        m_CurrentMenu = m_StartMenu;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Main Scene");
    }
    
    public void Menu(string Menu)
    {
        m_CurrentMenu.SetActive(false);

        switch (Menu)
        {
            case "Start":
                m_StartMenu.SetActive(true);
                m_CurrentMenu = m_StartMenu;
                break;
            case "Options":
                m_OptionsMenu.SetActive(true);
                m_CurrentMenu = m_OptionsMenu;
                break;
            case "Credits":
                m_Credits.SetActive(true);
                m_CurrentMenu = m_Credits;
                break;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
