using UnityEngine;

public class Note : MonoBehaviour {
    public float targetTime;   // 這個 note 應該被打擊的時間
    public float speed = 5f;   // 移動速度
    private AudioManager audio;

    void Start() {
        audio = FindObjectOfType<AudioManager>();
    }

    void Update() {
        // 簡單往下移動
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // 如果超過時間太久就刪掉
        if (audio.GetSongTime() - targetTime > 1.0f) {
            Destroy(gameObject);
        }
    }
}
