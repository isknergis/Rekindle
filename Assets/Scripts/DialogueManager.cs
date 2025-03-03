using TMPro; 
using UnityEngine;
public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;  // TextMeshProUGUI bileþeninin referansý.
    public string[] dialogues; // Diyaloglar dizisi
    private int currentDialogueIndex = 0;

    // Diyalog baþlatma fonksiyonu
    public void StartDialogue()
    {
        currentDialogueIndex = 0;  // Diyalog sýrasýný sýfýrla
        ShowNextDialogue();  // Ýlk diyalogu göster
    }

    // Bir sonraki diyaloðu gösterme fonksiyonu
    public void ShowNextDialogue()
    {
        if (currentDialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[currentDialogueIndex];  // Diyalog metnini güncelle
            currentDialogueIndex++;  // Sonraki diyaloga geç
        }
    }
}
