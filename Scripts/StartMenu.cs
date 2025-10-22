using UnityEngine;
using TMPro;

public class StartMenu : MonoBehaviour {
    public GameManager gameManager;
    public TextMeshProUGUI startText;

    private bool gameStarted = false;

    void Update() {
        if (!gameStarted) {
            float alpha = Mathf.Abs(Mathf.Sin(Time.time * 2f));
            startText.color = new Color(1, 1, 1, alpha);

            if (Input.GetKeyDown(KeyCode.Space)) {
                gameStarted = true;
                startText.gameObject.SetActive(false);
                gameManager.StartGame();
            }
        }
    }
}
