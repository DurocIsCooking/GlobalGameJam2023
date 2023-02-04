using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // TO DO:
        // Add text box open/close animation
        // Add SFX

    // Singleton pattern
    public static DialogueManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        DialogueBoxKiino.SetActive(false);
        DialogueBoxPotello.SetActive(false);
    }

    private GameObject _currentDialogueBox;
    private TextMeshProUGUI _currentDialogueText;
    public GameObject DialogueBoxKiino;
    public GameObject DialogueBoxPotello;
    public TextMeshProUGUI DialogueTextKiino;
    public TextMeshProUGUI DialogueTextPotello;
    private Queue<string> _sentences;
    [SerializeField] private float _typingDelay;
    private float _currentTypingDelay; // Need to set the typing delay to 0 when the player decides to skip dialogue
    private bool _isTypingSentence = false;

    public DialogueTrigger IncorrectItemDialogue;

    private void Start()
    {
        _sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        GameManager.Instance.SwitchGameState(GameManager.GameStates.Dialogue);

        if(dialogue.CharacterSpeaking == Dialogue.Characters.Kiino)
        {
            _currentDialogueBox = DialogueBoxKiino;
            _currentDialogueText = DialogueTextKiino;
        }
        else
        {
            _currentDialogueBox = DialogueBoxPotello;
            _currentDialogueText = DialogueTextPotello;
        }

        _currentDialogueBox.SetActive(true);

        _sentences.Clear();

        foreach (string sentence in dialogue.Sentences)
        {
            _sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void ProgressDialogue()
    {
        // If letters are currently appearing, finish sentence
        // Else...
        if(_isTypingSentence)
        {
            _currentTypingDelay = 0;
        }
        else
        {
            DisplayNextSentence();
        }
        
    }

    public void DisplayNextSentence()
    {
        _currentTypingDelay = _typingDelay;
        if (_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = _sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        _isTypingSentence = true;
        _currentDialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            _currentDialogueText.text += letter;
            yield return new WaitForSeconds(_currentTypingDelay);
        }
        _isTypingSentence = false;
    }

    public void EndDialogue()
    {
        GameManager.Instance.SwitchGameState(GameManager.GameStates.FreePlay);
        _currentDialogueBox.SetActive(false);
    }

    public void WrongItemDialogue()
    {
        transform.GetChild(0).GetComponent<DialogueTrigger>().TriggerDialogue();
    }
}
