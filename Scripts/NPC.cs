using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject dialoguebox;
    public bool activated=false;
   public GameObject buttons;
    void Start()
    {
        dialoguebox.SetActive(false);
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialoguebox.SetActive(true);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue,activated);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            buttons.SetActive(false);
            dialoguebox.SetActive(false);
        }
    }
}
