using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI NPC_Name;
    public TextMeshProUGUI NPC_DialogueText;

    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        NPC_Name.gameObject.SetActive(true);
        NPC_DialogueText.gameObject.SetActive(true);
        NPC_Name.text = dialogue.Name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence =  sentences.Dequeue();
        StopAllCoroutines();
        
        //NPC_DialogueText.text = sentence;
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        NPC_DialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            NPC_DialogueText.text += letter;
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void EndDialogue()
    {
        Debug.Log("End of Sentences");
        NPC_Name.gameObject.SetActive(false);
        NPC_DialogueText.gameObject.SetActive(false);
    }

}
