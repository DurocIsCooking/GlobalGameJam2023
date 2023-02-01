using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //---AUDIO SOURCES---//

    [Header("Audio Sources")]
    [SerializeField] private AudioSource m_BGMAudioSource;
    [SerializeField] private AudioSource m_SFXAudioSource;

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
                m_SFXAudioSource.PlayOneShot(m_CKey);
                break;
            case 2:
                m_SFXAudioSource.PlayOneShot(m_CSharpDFlatKey);
                break;
            case 3:
                m_SFXAudioSource.PlayOneShot(m_DKey);
                break;
            case 4:
                m_SFXAudioSource.PlayOneShot(m_DSharpEFlatKey);
                break;
            case 5:
                m_SFXAudioSource.PlayOneShot(m_EKey);
                break;
            case 6:
                m_SFXAudioSource.PlayOneShot(m_FKey);
                break;
            case 7:
                m_SFXAudioSource.PlayOneShot(m_FSharpGFlatKey);
                break;
            case 8:
                m_SFXAudioSource.PlayOneShot(m_GKey);
                break;
            case 9:
                m_SFXAudioSource.PlayOneShot(m_GSharpAFlatKey);
                break;
            case 10:
                m_SFXAudioSource.PlayOneShot(m_AKey);
                break;
            case 11:
                m_SFXAudioSource.PlayOneShot(m_ASharpBFlatKey);
                break;
            case 12:
                m_SFXAudioSource.PlayOneShot(m_BKey);
                break;
        }

        PianoPuzzle.Instance.CheckSolution(key);
    }
}
