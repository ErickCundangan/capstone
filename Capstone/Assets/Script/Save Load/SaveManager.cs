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

	public bool isStageCleared(int game, int stage) {
		if (game == 1)
			return (state.gameOneStagesCleared & (1 << stage)) != 0;
		
		if (game == 2)
			return (state.gameTwoStagesCleared & (1 << stage)) != 0;

		if (game ==	 3)
			return (state.gameThreeStagesCleared & (1 << stage)) != 0;

		if (game == 4)
			return (state.gameFourStagesCleared & (1 << stage)) != 0;

		return false;
	}

	public void completeStage(int game, int stage) {
		if (game == 1)
			state.gameOneStagesCleared |= 1 << stage;

		if (game == 2)
			state.gameTwoStagesCleared |= 1 << stage;

		if (game ==	 3)
			state.gameThreeStagesCleared |= 1 << stage;

		if (game == 4)
			state.gameFourStagesCleared |= 1 << stage;
	}
}
