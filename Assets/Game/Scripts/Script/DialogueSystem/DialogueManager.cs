using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

namespace MoreMountains.TopDownEngine
{
[AddComponentMenu("DialogueSystem/DialogueManager")]
public class DialogueManager : MMSingleton<DialogueManager>
{
    public GameObject childPrefab;
    public DialogueDatabase dialogueDatabase;

    void Start()
    {
        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");

        foreach (GameObject character in characters)
        {
            GameObject dialogue = Instantiate(childPrefab, character.transform);

            DialogueZone dialogueZone = dialogue.GetComponent<DialogueZone>();
            
            NPC npcData = character.GetComponent<NPC>();
            if (npcData != null)
            {
                DialogueData npcDialogue = GetDialogueDataForNPC(npcData.ID);
                if (npcDialogue != null)
                {
                    dialogueZone.Dialogue = new DialogueElement[npcDialogue.Dialogues.Count];

                    for (int i = 0; i < npcDialogue.Dialogues.Count; i++)
                    {
                        dialogueZone.Dialogue[i] = new DialogueElement();
                        dialogueZone.Dialogue[i].DialogueLine = npcDialogue.Dialogues[i];
                    }
                }
                else
                {
                    Debug.LogWarning($"No dialogues found for NPC with ID {npcData.ID}");
                }
            }
            else
            {
                Debug.LogError("NPC component missing on character GameObject.");
            }
        }
    }

    DialogueData GetDialogueDataForNPC(int npcID)
    {
        return dialogueDatabase.AllDialogues.Find(data => data.NPCID == npcID);
    }
}
}