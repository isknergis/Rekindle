using TMPro; 
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;  // UI - TMP Text
    public Button nextButton;             // UI - Buton
    public DialogueData dialogueData;     // ScriptableObject
    private int currentDialogueIndex = 0;
    private bool isDialogueActive = false;

    void Start()
    {
        nextButton.gameObject.SetActive(false); // Baþlangýçta buton gizli
    }

    public void StartDialogue()
    {
        currentDialogueIndex = 0;
        isDialogueActive = true;
        nextButton.gameObject.SetActive(true); // Butonu göster
        ShowNextDialogue();
    }

    public void ShowNextDialogue()
    {
        if (!isDialogueActive) return;

        if (currentDialogueIndex < dialogueData.dialogues.Count)
        {
            dialogueText.text = $"{dialogueData.dialogues[currentDialogueIndex].characterName}: {dialogueData.dialogues[currentDialogueIndex].dialogueText}";
            currentDialogueIndex++;
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        dialogueText.text = "";
        nextButton.gameObject.SetActive(false); // Butonu gizle
        isDialogueActive = false;
    }

}
