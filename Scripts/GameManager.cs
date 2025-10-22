using UnityEngine;

public class GameManager : MonoBehaviour {
    public AudioManager audioManager;
    public ScoreManager scoreManager;
    public NoteSpawner noteSpawner;
    public UIManager uiManager;

    private bool gameStarted = false;
    private bool gameEnded = false;

    void Update() {
        // 按空白鍵開始遊戲
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space)) {
            StartGame();
        }

        // 當音樂播完 → 遊戲結束
        if (gameStarted && !gameEnded && !audioManager.music.isPlaying) {
            EndGame();
        }
    }

    void StartGame() {
        gameStarted = true;
        gameEnded = false;

        // 重置分數與 Combo
        scoreManager.score = 0;
        scoreManager.combo = 0;
        uiManager.UpdateScore(0);
        uiManager.UpdateCombo(0);

        // 播放音樂
        audioManager.Play();

        Debug.Log("Game Started!");
    }

    void EndGame() {
        gameEnded = true;
        Debug.Log("Game Ended! Final Score: " + scoreManager.score);

        // 這裡可以呼叫 UIManager 顯示結果畫面
        uiManager.ShowJudgement("Game Over\nScore: " + scoreManager.score);
    }
}
