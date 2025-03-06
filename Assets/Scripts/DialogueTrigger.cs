using UnityEngine;



public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;  // `DialogueManager`'a referans.

    // Oyuncu alana girdi�inde diyalogu ba�latan fonksiyon
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // E�er oyuncu bu alana girerse
        {
            dialogueManager.StartDialogue();  // Diyalo�u ba�lat.
        }
    }

}


