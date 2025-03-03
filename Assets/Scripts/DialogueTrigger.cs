using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;  // DialogueManager referansý

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Eðer oyuncu bu alana girerse
        {
            dialogueManager.StartDialogue();  // Diyaloðu baþlat
        }
    }
}


