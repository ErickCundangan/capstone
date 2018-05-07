﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueHolder : MonoBehaviour {
    //DialogueSnippet delcarations
    private DialogueManager dManager;

    public  string  dialogueSpeaker;
    public  string[]dialogueLines;
    public  Sprite  dialogueSprite;

    private bool    playerInsideTrigger = false;

    public  int     exitHolder;
    
    // Use this for initialization
    void Start () {
        dManager = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        //DialogueSnippet
        if (playerInsideTrigger)
        {
            if (!dManager.dialogActive || (dManager.dialogActive && dManager.currentLine <= dManager.dialogLines.Length))
            {
                dManager.dialogSpeaker = dialogueSpeaker;
                dManager.dialogLines = dialogueLines;
                dManager.dialogSprite = dialogueSprite;
                if (exitHolder == 1)
                    dManager.exitValue = exitHolder--;
                else
                    dManager.exitValue = exitHolder;

                dManager.ShowDialogue();
            }
        }
        //end Dialogue
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Heneral Luna")
        {
            playerInsideTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Heneral Luna")
        {
            playerInsideTrigger = false;
        }
    }
}