using UnityEngine;

public class ChartLoader : MonoBehaviour {
    public TextAsset chartFile;
    public Chart chart;

    void Awake() {
        chart = JsonUtility.FromJson<Chart>(chartFile.text);
        Debug.Log("Loaded " + chart.notes.Length + " notes");
    }
}
