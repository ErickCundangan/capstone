using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    //UI
    public GameObject dBox;
    public Text dSpeaker;
    public Text dText;
    public Image dImage;

    //Data getter for dialogueHolder
    public string dialogSpeaker;
    public string[] dialogLines;
    public Sprite dialogSprite;
    public int exitValue;

    //Control
    public bool dialogActive;
    public int currentLine;

    public Animator animator;
    PlayerController thePlayer;

    private LoadNewArea LNArea;

    // Use this for initialization
    void Start () {
        dBox.SetActive(false);
        thePlayer = FindObjectOfType<PlayerController>();
        LNArea = FindObjectOfType<LoadNewArea>();
    }
	
	// Update is called once per frame  
	void Update () {

    }
    
    public void ShowDialogue()
    {
        dialogActive = true;
        dBox.SetActive(true);
        LNArea.ExitCounter += exitValue;
		LNArea.stopTime = true;

        if (currentLine == 0)
        {
            animator.SetBool("IsOpen", true);
        }

        if (dialogActive)
        {
            if (currentLine >= dialogLines.Length)
            {
                Close();

                currentLine = 0;
            }
            else
            {
                thePlayer.canMove = false;
                dSpeaker.text = dialogSpeaker;              //SpeakerName
                dImage.sprite = dialogSprite;               //Image sprite getter

                StopAllCoroutines();                        
                StartCoroutine(TypeSentence(dialogLines[currentLine])); //animation for text

                currentLine++;
            }
        }
    }

    IEnumerator TypeSentence (string sentence)
    {
        dText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dText.text += letter;
            yield return null;
        }
    }

    public void Close()
    {
		LNArea.stopTime = false;
        animator.SetBool("IsOpen", false);
        thePlayer.canMove = true;
    }
}
