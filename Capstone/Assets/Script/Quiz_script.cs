using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
		"15.\tThe “Cry of Pugadlawin” symbolizes the Katipuneros refusal to be ruled under Spain Tyrants",
		"16.\tWhich vehicle is popular before the American Period and exclusively owned only by rich family?",
		"17.\tGeneral Antonio Luna is not related to the famous painter Juan Luna.",
		"18.\tGeneral Luna help establish the first _______.",
		"19.\tAccording to General Federick Funston, an American general, who is “the ablest and most aggressive leader of the Filipino Republic”?",
		"20.\tWho said that General Antonio Luna “was the only general the Filipino army had”?",
		"21.\tWhen General Hughes said “The Filipinos only had one general, and they killed him”, who was General Hughes talking about?",
		"22.\tGeneral Antonio Luna was a scientist?",
		"23.\tIn the Philippines, what university did General Antonio Luna studied?",
		"24.\tDuring General Luna’s study in Sto. Thomas University, his scientific paper on what subject won a top prize.",
		"25.\tGeneral Luna graduated in the field of ______.",
		"26.\tIn Spain, what university did General Antonio Luna earned his license in pharmacy?",
		"27.\tIn Spain, what university did General Antonio Luna earned his doctorate in pharmacy?",
		"28.\tGeneral Luna was not a marksman.",
		"29.\tGeneral Luna was a martial artist.",
		"30.\tWhen did General Antonio Luna started practicing fencing, arnis and shooting gun?",
		"31.\tGeneral Antonio Luna was an avid student of military tactics when he was in highscool.",
		"32.\tGeneral Antonio Luna was a legend when using a gun that he can unlit a candle in one shot.",
		"33.\tGeneral Luna’s a master of what type of weapon?",
		"34.\tGeneral Luna trained a group of elite soldiers famously name as ______.",
		"35.\tDuring General Luna’s charge, what saved General Luna from a bullet aimed at his chest?",
		"36.\tWho among the following is not an enemy of General Luna.",
		"37.\tGeneral Luna was killed by American soldiers.",
		"38.\tGeneral Luna almost had a duel with ______.",
		"39.\tGeneral Antonio Luna and Dr. Jose Rizal almost had a duel because the former disrespected _______.",
		"40.\tWhat country did General Antonio Luna studied the art of war?",
		"41.The archipelago of the Philippines consists of how many islands?",
		"42. What was the aftermath of General Antonio Luna’s assassination?",
		"43. General Luna’s last words were “Cowards! Assassins”.",
		"44.\tThe blue color of the Philippine flag symbolizes _____.",
		"45.\tWhat country colonized the Philippines after Spain?",
		"46.\t In the Philippine flag, what symbolizes liberty?",
		"47.\t In the Philippine flag, what symbolizes Filipino’s hope for equality",
		"48.\t The red stripe found in the Philippine flag symbolizes ____.",
		"49.\t The blue stripe found in the Philippine flag symbolizes ______.",
		"50.\t What is the favorite article of General Antonio Luna when implementing discipline to Filipino soldiers."
	};

	// Use this for initialization
	void Start () {
      //  GetComponent<TextMesh>().text = questions[0];
		GetComponent<Text>().text = questions[9].ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
