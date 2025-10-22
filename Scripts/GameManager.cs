using UnityEngine;

public class GameManager : MonoBehaviour {
    public AudioManager audioManager;
    public ScoreManager scoreManager;
    public NoteSpawner noteSpawner;
    public UIManager uiManager;

    private bool gameStarted = false;
    private bool gameEnded = false;

    void Update() {
        if (gameStarted && !gameEnded && !audioManager.music.isPlaying) {
            EndGame();
        }
    }

    public void StartGame() {
        gameStarted = true;
        gameEnded = false;

        scoreManager.score = 0;
        scoreManager.combo = 0;
        uiManager.UpdateScore(0);
        uiManager.UpdateCombo(0);

        audioManager.Play();
        Debug.Log("Game Started!");
    }

    void EndGame() {
        gameEnded = true;
        Debug.Log("Game Ended! Final Score: " + scoreManager.score);
        uiManager.ShowJudgement("Game Over\nScore: " + scoreManager.score);
    }
}
