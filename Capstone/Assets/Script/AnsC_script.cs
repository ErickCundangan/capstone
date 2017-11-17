using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnsC_script : MonoBehaviour{

	List<string> ChoiceC = new List<string>() { "KKK",
		"Phases during the revolution",
		"June 21, 1989",
		"Cuba",
		"Agimat",
		"Agimat sa sulat",
		"Agimat",
		" ",
		"Spear",
		"Spear",
		" ",
		"Pedro Gil, Manila",
		"August 23, 1896",
		"c.\tThe Katipuneros first victorious battle against the Spaniards",
		" ",
		"Bicycle",
		" ",
		"Mansion for Filipinos",
		"General Antonio Luna",
		"General Federick Funston",
		"Dr. Jose Rizal",
		" ",
		"De La Salle University",
		"Military",
		"Medical doctor",
		"Universidad de Barcelona",
		"Unversidad Central de Madrid",
		" ",
		" ",
		"College",
		" ",
		" ",
		"Spear",
		"Luna Riflemen",
		"A bag of coins",
		"President Emilio Aguinaldo",
		" ",
		"Juan Luna",
		"Jose Rizal’s friend",
		"America",
		"7,107",
		"c.\tThe Philippine army regroup and defended the country successfully",
		" ",
		" ",
		"Cuba",
		"Blue stripe",
		"Blue stripe",
		"Blood sacrificed by the Filipinos",
		"Blood sacrificed by the Filipinos",
		"Artikulo V",
	};

    // Use this for initialization
    void Start()
    {
		//  GetComponent<TextMesh>().text = questions[0];
		GetComponent<Text>().text = ChoiceC[49].ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
