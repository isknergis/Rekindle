using TMPro; 
using UnityEngine;
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;  // TextMeshProUGUI bile�eninin referans�.
    public string[] dialogues; // Diyaloglar dizisi
    private int currentDialogueIndex = 0;

    // Diyalog ba�latma fonksiyonu
    public void StartDialogue()
    {
        currentDialogueIndex = 0;  // Diyalog s�ras�n� s�f�rla
        ShowNextDialogue();  // �lk diyalogu g�ster
    }

    // Bir sonraki diyalo�u g�sterme fonksiyonu
    public void ShowNextDialogue()
    {
        if (currentDialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[currentDialogueIndex];  // Diyalog metnini g�ncelle
            currentDialogueIndex++;  // Sonraki diyaloga ge�
        }
    }
}
