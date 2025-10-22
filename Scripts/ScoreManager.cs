using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public UIManager ui;
    public int score = 0;
    public int combo = 0;

    public void AddScore(int amount) {
        score += amount;
        combo++;
        ui.UpdateScore(score);
        ui.UpdateCombo(combo);
    }

    public void ResetCombo() {
        combo = 0;
        ui.UpdateCombo(combo);
    }
}
