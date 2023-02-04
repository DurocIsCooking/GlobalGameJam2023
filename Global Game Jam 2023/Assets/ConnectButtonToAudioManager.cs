using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ConnectButtonToAudioManager : MonoBehaviour
{
    public string SfxString;

    // Start is called before the first frame update
    void Start()
    {
        Button button = gameObject.GetComponent<Button>();

        button.onClick.AddListener(delegate { ConnectToManager(SfxString); });

    }

    void ConnectToManager(string sfx)
    {
        AudioManager.Instance.PlaySFX(sfx);
    }
}