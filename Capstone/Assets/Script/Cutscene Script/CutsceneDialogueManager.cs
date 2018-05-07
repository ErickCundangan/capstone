using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CutsceneDialogueManager : MonoBehaviour {
	//UI
	public CutsceneDialogueHolder[] dialog;
	int i = 0;

	public GameObject dBox;
	public Text dSpeaker;
	public Text dText;
	public Image dImage;

	//Data getter for dialogueHolder
	public string dialogSpeaker;
	public string[] dialogLines;
	public Sprite dialogSprite;

	//Control
	public bool dialogActive;
	public int currentLine;

	public Animator animator;
	public GameObject canvas;
	public string sceneToLoad;

	// Use this for initialization
	void Start () {
		dBox.SetActive(false);
		Button btn = canvas.GetComponent<Button> ();
		btn.interactable = false;
	}

	// Update is called once per frame  
	void Update () {

	}

	public void ShowDialogue()
	{
		if (i < dialog.Length) {
			dialogSpeaker = dialog [i].dialogueSpeaker;
			dialogLines = dialog [i].dialogueLines;
			dialogSprite = dialog [i].dialogueSprite;
		} else {
			EndCutScene ();
			return;
		}

		dialogActive = true;
		dBox.SetActive(true);

		if (currentLine == 0)
		{
			animator.SetBool("IsOpen", true);
		}

		if (dialogActive)
		{
			if (currentLine >= dialogLines.Length)
			{
				i++;
				currentLine = 0;
				ShowDialogue ();
			}
			else
			{
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

	public void EnableClicking()
	{
		Button btn = canvas.GetComponent<Button> ();
		btn.interactable = true;
	}

	public void EndCutScene() {
		Animator canvasAnim = canvas.GetComponent<Animator> ();
		canvasAnim.SetBool ("isCutsceneDone", true);
	}
}

