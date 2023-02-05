using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used this tutorial for dialogue system: https://www.youtube.com/watch?v=_nRzoTzeyxU&ab_channel=Brackeys

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
