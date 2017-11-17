using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnsA_script : MonoBehaviour{

    List<string> ChoicesA = new List<string>() { "CALABARZONS",
		"Provinces who fought against Spain",
		"May 28, 1989",
		"America",
		"Flag",
		"Agimat na sinusuot",
		"Pluma",
		"True",
		"Revolver",
		"Revolver",
		"True",
		"Tondo, Manila",
		"August 30, 1896",
		"The Katipuneros cry due to hardship",
		"True",
		"Jeep",
		"True",
		"School for  Filipinos",
		"General Arthur McArthur",
		"President Emilio Aguinaldo",
		"President Emilio Aguinaldo",
		"True",
		"Ateneo University",
		"Chemistry",
		"Engineering",
		"Universidad Autònoma de Madrid",
		"Universidad Autònoma de Madrid",
		"True",
		"True",
		"Elementary",
		"True",
		"True",
		"Gun",
		"Luna Sharpshooters",
		"A medal",
		"General Federick Funston",
		"True",
		"Dr. Jose Rizal",
		"A military general",
		"Belgium",
		"7,000",
		"The Philippine army suffered continuous defeat",
		"True",
		" ",
		"Japan",
		"Sun",
		"3 stars and the sun",
		"Valor and patriotism",
		"Valor and patriotism",
		"Artikulo I"
	};

    // Use this for initialization
    void Start()
    {
		//  GetComponent<TextMesh>().text = questions[0];
		GetComponent<Text>().text = ChoicesA[49].ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
