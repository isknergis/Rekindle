using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;  // DialogueManager referans�

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // E�er oyuncu bu alana girerse
        {
            dialogueManager.StartDialogue();  // Diyalo�u ba�lat
        }
    }
}


