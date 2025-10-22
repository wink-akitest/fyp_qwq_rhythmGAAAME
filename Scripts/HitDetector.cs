using UnityEngine;

public class HitDetector : MonoBehaviour {
    public AudioManager audio;
    public ScoreManager scoreManager;
    public HitDirector hitDirector;

    void Update() {
        if (Input.GetKeyDown(KeyCode.A)) CheckHit(0);
        if (Input.GetKeyDown(KeyCode.S)) CheckHit(1);
        if (Input.GetKeyDown(KeyCode.D)) CheckHit(2);
        if (Input.GetKeyDown(KeyCode.F)) CheckHit(3);
    }

    void CheckHit(int lane) {
        float current = audio.GetSongTime();

        // 找這個 lane 上最近的 note
        Note[] notes = FindObjectsOfType<Note>();
        Note closest = null;
        float minDiff = Mathf.Infinity;

        foreach (Note n in notes) {
            if (n.lane != lane) continue; // 只檢查對應 lane
            float diff = Mathf.Abs(n.targetTime - current);
            if (diff < minDiff) {
                minDiff = diff;
                closest = n;
            }
        }

        if (closest != null) {
            string result = "Miss";
            int score = 0;

            if (minDiff <= 0.05f) { result = "Perfect"; score = 300; }
            else if (minDiff <= 0.10f) { result = "Great"; score = 200; }
            else if (minDiff <= 0.15f) { result = "Good"; score = 100; }
            else { result = "Miss"; scoreManager.ResetCombo(); }

            if (score > 0) {
                scoreManager.AddScore(score);
                Destroy(closest.gameObject);
            }

            hitDirector.ShowHit(result);
        }
    }
}
