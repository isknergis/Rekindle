using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue System/Dialogue Section")]
public class DialogueData : ScriptableObject
{
    [System.Serializable]
    public class DialogueLine
    {
        public string characterName; // Konu�an karakterin ad�
        public string dialogueText; // Diyalog i�eri�i
    }

    public List<DialogueLine> dialogues; // Diyalog listesi
}
