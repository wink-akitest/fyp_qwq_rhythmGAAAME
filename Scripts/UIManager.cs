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
        comboText.text = combo > 0 ? "Combo: " + combo : "";
    }

    public void ShowJudgement(string judgement) {
        judgementText.text = judgement;
        CancelInvoke("ClearJudgement");
        Invoke("ClearJudgement", 0.5f); // 半秒後清空
    }

    void ClearJudgement() {
        judgementText.text = "";
    }
}
