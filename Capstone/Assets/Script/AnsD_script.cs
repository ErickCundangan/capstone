using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnsD_script : MonoBehaviour{

	List<string> ChoiceD = new List<string>() { "Courage, bravery, and honor", 
		"Important events in Philipine History",
		"June 21, 1989",
		"China",
		"Sto. Nino",
		"Agimat sa dugo",
		"Flag",
		" ",
		"Sword",
		"Sword",
		" ",
		"Malate, Manila",
		"June 23, 1896",
		"d.\tThe Katipuneros appointed Andres Bonifacio as the supremo",
		" ",
		"Tricycle",
		" ",
		"Military base for Filipinos",
		"General Gregorio del Pilar",
		"General James Franklin Bell",
		"General Antonio Luna",
		" ",
		"University of the Philippines",
		"Biology",
		"Pharmacy",
		"Universidad Complutense Madrid",
		"University of Valladolid",
		" ",
		" ",
		"Military days",
		" ",
		" ",
		"Slingshot",
		"Luna Marksmen",
		"A booklet",
		"General Irving Hale",
		" ",
		"President Emilio Aguinaldo",
		"A novel Spaniard",
		"Philippines",
		"7,700",
		"d.\tThe Philippine army was disciplined",
		" ",
		" ",
		"China",
		"Red  stripe",
		"Red  stripe",
		"Peace, justice, and truth",
		"Peace, justice, and truth",
		"Artikulo VI",
	};

    // Use this for initialization
    void Start()
    {
		//  GetComponent<TextMesh>().text = questions[0];
		GetComponent<Text>().text = ChoiceD[9].ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
