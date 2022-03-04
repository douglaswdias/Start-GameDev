using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{

    public float dialogueRange;
    public LayerMask playerLayer;

    public DialogueSettings dialogue;


    private bool playerHit;

    private List<string> sentences = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        GetNpcInfo();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            DialogueControl.Instance.Speech(sentences.ToArray());
        }
    }

    private void GetNpcInfo()
    {
        for(int i = 0; i < dialogue.dialogues.Count; i++)
        {
            switch (DialogueControl.Instance.language)
            {
                case DialogueControl.lang.pt:
                    sentences.Add(dialogue.dialogues[i].sentence.portuguese);
                break;

                case DialogueControl.lang.en:
                    sentences.Add(dialogue.dialogues[i].sentence.english);
                break;

                case DialogueControl.lang.sp:
                    sentences.Add(dialogue.dialogues[i].sentence.spanish);
                break;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if(hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit=false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
