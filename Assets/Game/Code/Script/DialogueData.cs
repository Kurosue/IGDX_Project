using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueData
{
    public int NPCID;
    [TextArea] public List<string> Dialogues;
}