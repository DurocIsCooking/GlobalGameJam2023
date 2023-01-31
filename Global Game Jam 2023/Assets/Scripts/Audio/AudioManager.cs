using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //---SFX CLIPS---//

    [Header("SFX - Piano Keys")]
    [SerializeField] private AudioClip m_CKey;
    [SerializeField] private AudioClip m_CSharpDFlatKey;
    [SerializeField] private AudioClip m_DKey;
    [SerializeField] private AudioClip m_DSharpEFlatKey;
    [SerializeField] private AudioClip m_EKey;
    [SerializeField] private AudioClip m_FKey;
    [SerializeField] private AudioClip m_FSharpGFlatKey;
    [SerializeField] private AudioClip m_GKey;
    [SerializeField] private AudioClip m_GSharpAFlatKey;
    [SerializeField] private AudioClip m_AKey;
    [SerializeField] private AudioClip m_ASharpBFlatKey;
    [SerializeField] private AudioClip m_BKey;

    //---SINGLETON---//

    private static AudioManager instance;

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject();
                    singleton.AddComponent<AudioManager>();
                    singleton.name = "(Singleton) AudioManager";
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    //---PIANO KEYS FUNCTIONALITY---//

    public void PlayKey(int key)
    {
        switch (key)
        {
            case 1:
                Debug.Log("C key");
                break;
            case 2:
                Debug.Log("C#/Db key");
                break;
            case 3:
                Debug.Log("D key");
                break;
            case 4:
                Debug.Log("D#/Eb key");
                break;
            case 5:
                Debug.Log("E key");
                break;
            case 6:
                Debug.Log("F key");
                break;
            case 7:
                Debug.Log("F#/Gb key");
                break;
            case 8:
                Debug.Log("G key");
                break;
            case 9:
                Debug.Log("G#/Ab key");
                break;
            case 10:
                Debug.Log("A key");
                break;
            case 11:
                Debug.Log("A#/Bb key");
                break;
            case 12:
                Debug.Log("B key");
                break;
        }
    }
}
