using UnityEngine;
using TMPro;

public class StartMenu : MonoBehaviour {
    public GameManager gameManager;
    public TextMeshProUGUI startText;

    private bool gameStarted = false;

    void Update() {
        if (!gameStarted) {
            // 閃爍提示文字
            float alpha = Mathf.Abs(Mathf.Sin(Time.time * 2f));
            startText.color = new Color(1, 1, 1, alpha);

            // 按下空白鍵開始遊戲
            if (Input.GetKeyDown(KeyCode.Space)) {
                gameStarted = true;
                startText.gameObject.SetActive(false);
                gameManager.StartGame();
            }
        }
    }
}
