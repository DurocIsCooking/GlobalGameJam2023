using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //---AUDIO SOURCES---//

    [Header("Audio Sources")]
    [SerializeField] private AudioSource m_BGMAudioSourceIntro;
    [SerializeField] private AudioSource m_BGMAudioSourceLoop;
    [SerializeField] private AudioSource m_SFXAudioSource;
    [SerializeField] private AudioMixer m_AudioMixer;

    //---BGM CLIPS---//

    [Header("BGM")]
    [SerializeField] private AudioClip m_BGMIntro;
    [SerializeField] private AudioClip m_BGMLoop;
    [SerializeField] private AudioClip m_BGMFinal;
    private float m_BGMOriginalVolume;

    [SerializeField] private float m_FadeSpeed;
    [SerializeField] private bool m_FadeIn;
    [SerializeField] private bool m_FadeOut;

    //---SFX CLIPS---//

    [Header("SFX")]
    [SerializeField] private AudioClip m_SFXPickUp;
    [SerializeField] private AudioClip m_SFXKey;
    [SerializeField] private AudioClip m_SFXUnlock;
    [SerializeField] private AudioClip m_SFXPaper;
    [SerializeField] private AudioClip m_SFXBook;
    [SerializeField] private AudioClip m_SFXKettle;
    [SerializeField] private AudioClip m_SFXTimeTravel;
    [SerializeField] private AudioClip m_SFXClick;
    [SerializeField] private AudioClip m_SFXTick;
    [SerializeField] private AudioClip m_SFXTock;

    private bool m_TickLastPlayed;
    private bool m_TockLastPlayed;

    [Header("SFX - Menu")]
    [SerializeField] private AudioClip m_MenuClick;
    [SerializeField] private AudioClip m_MenuHover;

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

    private string m_PreviousSFX = "";
    private float m_SFXOriginalVolume;

    //---VOICE CLIPS---//
    
    [Header("Voice")]
    [SerializeField] private AudioClip m_Voice_Potello; //To be renamed once we know what Voice clips we'll need.
    [SerializeField] private AudioClip m_Voice_Kiino;

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

    private void Start()
    {
        m_TockLastPlayed = true;

        //---SETS AND PLAYS THE INITIAL VOLUMES AND AUDIO CLIPS---//
        m_SFXOriginalVolume = m_SFXAudioSource.volume;

        m_BGMOriginalVolume = m_BGMAudioSourceIntro.volume;
        m_BGMAudioSourceLoop.volume = m_BGMAudioSourceIntro.volume;

        m_BGMAudioSourceIntro.clip = m_BGMIntro;
        m_BGMAudioSourceLoop.clip = m_BGMLoop;
        m_BGMAudioSourceLoop.loop = true;

        m_BGMAudioSourceIntro.Play();
        m_BGMAudioSourceLoop.PlayDelayed(m_BGMAudioSourceIntro.clip.length);
    }

    private void Update()
    {
        //---FADES THE BGM---//

        if(m_FadeOut)
        {
            m_BGMAudioSourceIntro.volume -= m_FadeSpeed * Time.deltaTime;
            m_BGMAudioSourceLoop.volume -= m_FadeSpeed * Time.deltaTime;

            if(m_BGMAudioSourceIntro.volume <= 0 && m_BGMAudioSourceLoop.volume <= 0)
            {
                m_FadeOut = false;
            }
        }

        if (m_FadeIn)
        {
            m_BGMAudioSourceIntro.volume += m_FadeSpeed * Time.deltaTime;
            m_BGMAudioSourceLoop.volume += m_FadeSpeed * Time.deltaTime;

            if(m_BGMAudioSourceIntro.volume >= m_BGMOriginalVolume && m_BGMAudioSourceLoop.volume >= m_BGMOriginalVolume)
            {
                m_FadeIn = false; 
            }
        }
    }

    //---MIXER VOLUMES---//

    public void MasterVol(float MasterSlider)
    {
        m_AudioMixer.SetFloat("m_MasterVol", Mathf.Log10(MasterSlider) * 20);
    }

    public void BGMVol(float BGMSlider)
    {
        m_AudioMixer.SetFloat("m_BGMVol", Mathf.Log10(BGMSlider) * 20);
    }

    public void SFXVol(float SFXSlider)
    {
        m_AudioMixer.SetFloat("m_SFXVol", Mathf.Log10(SFXSlider) * 20);
    }


    //---BGM---//

    public void PlayBGM()
    {
        m_FadeOut = false;
        m_FadeIn = true;
    }

    public void StopBGM()
    {
        m_FadeIn = false;
        m_FadeOut = true;
    }

    //---SFX---//

    public void PlaySFX(string SFX)
    {
        m_SFXAudioSource.volume = m_SFXOriginalVolume;

        switch (SFX)
        {
            case "Pickup":
                m_SFXAudioSource.PlayOneShot(m_SFXPickUp);
                break;
            case "Key":
                m_SFXAudioSource.PlayOneShot(m_SFXKey);
                break;
            case "Unlock":
                m_SFXAudioSource.PlayOneShot(m_SFXUnlock);
                break;
            case "Paper":
                m_SFXAudioSource.PlayOneShot(m_SFXPaper);
                break;
            case "Book":
                m_SFXAudioSource.PlayOneShot(m_SFXBook);
                break;
            case "Kettle":
                m_SFXAudioSource.PlayOneShot(m_SFXKettle);
                break;
            case "Time Travel":
                m_SFXAudioSource.PlayOneShot(m_SFXTimeTravel);
                break;
            case "Click":
                m_SFXAudioSource.PlayOneShot(m_SFXClick, 0.5f);
                break;
            case "TickTock":
                if(m_TockLastPlayed)
                {
                    m_TockLastPlayed = false;
                    m_SFXAudioSource.PlayOneShot(m_SFXTick, 0.3f);
                    m_TickLastPlayed = true;
                }
                else if (m_TickLastPlayed)
                {
                    m_TickLastPlayed = false;
                    m_SFXAudioSource.PlayOneShot(m_SFXTock, 0.3f);
                    m_TockLastPlayed = true;
                }
                break;
            case "Menu Click":
                m_SFXAudioSource.PlayOneShot(m_MenuClick, 0.3f);
                break;
            case "Menu Hover":

                m_SFXAudioSource.volume = 0.3f;

                if (m_PreviousSFX == "Hover")
                {
                    m_SFXAudioSource.Stop();
                }

                m_SFXAudioSource.clip = m_MenuHover;
                m_SFXAudioSource.Play();
                break;
        }

        m_PreviousSFX = SFX;
    }

    public void PlayVoice(string Character)
    {
        switch (Character)
        {
            case "Potello":
                m_SFXAudioSource.PlayOneShot(m_Voice_Potello, 0.6f);
                break;

            case "Kiino":
                m_SFXAudioSource.PlayOneShot(m_Voice_Kiino, 0.6f);
                break;
        }
    }

    //---PIANO FUNCTIONALITY---//

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

    public void PianoPuzzleSolve()
    {
        m_BGMAudioSourceLoop.Stop();                        //Stops the faded out loop.
        m_BGMAudioSourceLoop.clip = m_BGMFinal;             //Switches to the final track.
        m_BGMAudioSourceLoop.volume = m_BGMOriginalVolume;  //Resets the volume.
        m_BGMAudioSourceLoop.PlayDelayed(2.0f);             //Plays the final track.
    }
}
