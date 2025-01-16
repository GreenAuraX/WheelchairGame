using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
   
    private Queue<string> sentences;

    public TMPro.TextMeshProUGUI nameText;
    public TMPro.TextMeshProUGUI dialogueText;

    public GameObject uiElement1;
    public GameObject uiElement2;
    public GameObject uiElement3;
    public GameObject uiElement4;
    public GameObject uiElement5;
    public GameObject uiElement6;
    public GameObject uiElement7;
    public GameObject uiElement8;
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            UiStop();
            ObjOn();
            return;
            
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        Debug.Log(sentence);
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation.");
    }

    public void UiStop()
    {
        uiElement1.SetActive(false);
        uiElement2.SetActive(false);
        uiElement3.SetActive(false);
        uiElement4.SetActive(false);
        uiElement5.SetActive(false);
        uiElement6.SetActive(false);
    }
    public void ObjOn()
    {
        uiElement7.SetActive(true);
        uiElement8.SetActive(true);
    }
}

