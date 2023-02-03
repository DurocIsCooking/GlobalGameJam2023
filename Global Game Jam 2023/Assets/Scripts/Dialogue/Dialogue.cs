using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public enum Characters
    {
        Kiino,
        Potello
    }
    public Characters CharacterSpeaking;

    [TextArea(3,10)]
    public string[] Sentences;
}
