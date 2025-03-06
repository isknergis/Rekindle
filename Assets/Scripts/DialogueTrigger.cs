using UnityEngine;



public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;  // `DialogueManager`'a referans.

    // Oyuncu alana girdiðinde diyalogu baþlatan fonksiyon
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Eðer oyuncu bu alana girerse
        {
            dialogueManager.StartDialogue();  // Diyaloðu baþlat.
        }
    }

}


