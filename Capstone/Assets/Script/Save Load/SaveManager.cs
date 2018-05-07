using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {
	public static SaveManager Instance { set; get; }
	public SaveState state;
	public string currentUser;
	private void Awake() {
		DontDestroyOnLoad (this);
		Instance = this;
	}

	public void Save(string username) {
		PlayerPrefs.SetString(username, Helper.Serialize<SaveState>(state));

		currentUser = username;
	}

	public bool Load(string username, string password) {
		if (PlayerPrefs.HasKey (username)) {
			state = Helper.Deserialize<SaveState>(PlayerPrefs.GetString(username));
			if (password.Equals (state.password)) {
				currentUser = username;
				return true;
			} else {
				state = new SaveState ();
				return false;
			}
				
		} else {
			return false;
		}

	}

	public bool NewGame(string username, string password) {
		if (!CheckIfUsernameExists(username)) {
			state = new SaveState ();
			state.password = password;
			Save (username);
			return true;
		} else {
			return false;
		}
	}

	bool CheckIfUsernameExists (string username) {
		if (PlayerPrefs.HasKey (username))
			return true;
		else
			return false;
	}

	public bool isStageCleared(int game, int stage) {
		if (game == 1)
			return (state.gameOneStagesCleared & (1 << stage)) != 0;
		
		if (game == 2)
			return (state.gameTwoStagesCleared & (1 << stage)) != 0;

		if (game ==	3)
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

	public void SetPreQuizScore(int score) {
		state.isPreQuizDone = true;
		state.preQuizScore = score;
	}

	public void SetPostQuizScore(int score) {
		state.isPostQuizDone = true;
		state.postQuizScore = score;
	}
}
