using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueDatabase", menuName = "DialogueSystem/DialogueDatabase")]
public class DialogueDatabase : ScriptableObject
{
    public List<DialogueData> AllDialogues;
}
