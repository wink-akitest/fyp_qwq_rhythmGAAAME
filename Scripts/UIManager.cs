using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboText;
    public TextMeshProUGUI judgementText;

    public void UpdateScore(int score) {
        scoreText.text = "Score: " + score;
    }

    public void UpdateCombo(int combo) {
        comboText.text = "Combo: " + combo;
    }

    public void ShowJudgement(string text) {
        judgementText.text = text;
    }
}
