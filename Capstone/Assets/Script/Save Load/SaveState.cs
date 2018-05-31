public class SaveState {
	public bool isPreQuizDone = false;
	public bool isPostQuizDone = false;
	public string password;
	public int preQuizScore = 0;
	public int gameOneStagesCleared = 0;
	public int gameTwoStagesCleared = 0;
	public int gameThreeStagesCleared = 0;
	public int gameFourStagesCleared = 0;
	public int postQuizScore = 0;
	public float bgmVolume = 1f;
	public float sfxVolume = 1f;
	public int[] gameOneScores = new int[4];
	public int[] gameTwoScores = new int[5];
	public int[] gameThreeScores = new int[5];
	public int[] gameFourScores = new int[2];
}
