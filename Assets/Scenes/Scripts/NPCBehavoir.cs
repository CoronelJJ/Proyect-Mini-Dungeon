using UnityEngine;

public class NPCBehavoir : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindAnyObjectByType<DialogManager>().StartDialogue(dialogue);
    }
}
