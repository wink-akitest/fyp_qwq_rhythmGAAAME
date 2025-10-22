using UnityEngine;

public class ChartLoader : MonoBehaviour {
    public TextAsset chartFile; // 拖進 Inspector
    public Chart chart;

    void Awake() {
        chart = JsonUtility.FromJson<Chart>(chartFile.text);
        Debug.Log("Loaded chart with " + chart.notes.Count + " notes");
    }
}
