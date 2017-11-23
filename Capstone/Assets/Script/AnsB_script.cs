using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnsB_script : MonoBehaviour{

    List<string> ChoiceB = new List<string>() { "Luzon, Visayas, and Mindanao",
		"Heroes of the Philippines.",
		"May 1, 1989",
		"tSpain",
		"Dagger",
		"Agimat sa loob",
		"Sword",
		"False",
		"Bolo",
		"Bolo",
		"False",
		"Taft, Manila",
		"June 30, 1896",
		"The Katipuneros tear their cedula",
		"False",
		"Kalesa",
		"False",
		"Military academy for Filipinos",
		"Emilio Aguinaldo",
		"Andres Bonifacio",
		"Andres Bonifacio",
		"False",
		"Sto. Thomas University",
		"Physics",
		"Mathematics",
		"Universidad of Navarra",
		"University of La Laguna",
		"False",
		"False",
		"Highschool",
		"False",
		"False",
		"Sword",
		"Luna Death Squad",
		"An agimat",
		"General Arthur MacArthur",
		"False",
		"Andres Bonifacio",
		"A woman courted by both men",
		"Spain",
		"7,707",
		"The Philippine army defeated the Americans",
		"False",
		" ",
		"America",
		"Star",
		"White triangle",
		"Anger and Hate",
		"Anger and Hate",
		"Artikulo II"
	};

    // Use this for initialization
    void Start()
    {
		//  GetComponent<TextMesh>().text = questions[0];
		GetComponent<Text>().text = ChoiceB[9].ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
