using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue1;
    public Dialogue dialogue2;
    public Dialogue dialogue3;

    public bool GuardPart1 = false;
    public bool GuardPart2 = false;
    public bool DPart1 = false;
    public bool DPart2 = false;

    public float TimertoOpen = 5;
    public GameObject MainDoor;
    public Animator MainDoorAnim;

    public NPC_Interaction NPC;

    private void Start()
    {
        MainDoorAnim = MainDoor.GetComponent<Animator>();
    }

    public void TriggerDialogue()
    {
        if (NPC.CurrentHitObject.name == "Guard1")
        {
            if (GuardPart1 == false)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue1);
                GuardPart1 = true;
                MainDoorAnim.SetBool("OpenDoor", true);
            }

            else if (GuardPart1 == true && DPart1 == false)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue2);
            }

            else if(GuardPart1 == true && DPart1 == true)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue3);
                GuardPart2 = true;
            }
            else if(GuardPart2 == true)
            {
                return;
            }
        }

        if(NPC.CurrentHitObject.name == "Doctor")
        {
            if (DPart1 == false)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue1);
                GameObject.Find("Guard1").GetComponent <DialogueTrigger>().DPart1 = true;
                DPart1 = true;
            }
        }   
    }
}
