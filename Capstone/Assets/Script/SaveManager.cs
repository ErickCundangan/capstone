using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {
	public static SaveManager Instance { set; get; }
	public SaveState state;

	private void Awake() {
		DontDestroyOnLoad (this);
		Instance = this;
		Load ();
	}

	public void Save() {
		PlayerPrefs.SetString("save", Helper.Serialize<SaveState>(state));
	}

	public void Load() {
		if (PlayerPrefs.HasKey ("save")) {
			state = Helper.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
		} else {
			state = new SaveState();
			Save();
		}
	}

}
