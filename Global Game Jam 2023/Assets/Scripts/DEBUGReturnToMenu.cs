using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DEBUGReturnToMenu : MonoBehaviour
{
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }    
}
