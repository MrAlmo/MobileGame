using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string npcText;
    public DialogueOption[] options;
    public DialogueOutcome outcome;
}
