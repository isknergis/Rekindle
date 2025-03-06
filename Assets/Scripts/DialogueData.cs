using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue System/Dialogue Section")]
public class DialogueData : ScriptableObject
{
    [System.Serializable]
    public class DialogueLine
    {
        public string characterName; // Konuþan karakterin adý
        public string dialogueText; // Diyalog içeriði
    }

    public List<DialogueLine> dialogues; // Diyalog listesi
}
