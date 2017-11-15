using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class Quiz_script : MonoBehaviour {

    List<string> questions = new List<string>() { "1. What does the 3 star  in the Philippine flag symbolize?",
		"2. What does the 8 ray of the sun in the Philippine flag symbolize?",
		"3. When was the Philippine flag first displayed in battle?",
		"4.	What country flag gave inspiration for the design of the Philippine flag?",
		"5. What is a special object that either gives power or protect it’s keeper.",
		"6. Which is not considered as an Agimat?",
		"7. What is made from a big bird’s feather?",
		"8. Pluma is know to be used by writers and soldiers in battle.",
		"9.\tWhich is Andres Bonifacio’s weapon of choice?",
		"10.\tWhich weapon is usually used by the Katipuneros?",
		"11.\tKKK stands for Kataastaasang Kagalanggalangang Katipunan ng mga Anak ng Bayan.",
		"12.\tWhere did Andres Bonifacio founded KKK.",
		"13.\tWhen did the “Cry of Pugadlawin” happened?",
		"14.\tWhat transpired during the historical event of “Cry of Pugadlawin”",
		};

	// Use this for initialization
	void Start () {
        GetComponent<TextMesh>().text = questions[0];
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
