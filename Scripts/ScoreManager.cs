using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public int score = 0;
    public int combo = 0;

    public void AddScore(string judgement) {
        switch (judgement) {
            case "Perfect":
                score += 1000;
                combo++;
                break;
            case "Great":
                score += 700;
                combo++;
                break;
            case "Good":
                score += 300;
                combo = 0;
                break;
            case "Miss":
                combo = 0;
                break;
        }
        Debug.Log(judgement + " | Score: " + score + " | Combo: " + combo);
    }
}
