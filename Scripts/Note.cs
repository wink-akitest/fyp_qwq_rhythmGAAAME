using UnityEngine;

public class Note : MonoBehaviour {
    public float targetTime;
    public float speed = 5f;

    void Update() {
        transform.position += Vector3.down * speed * Time.deltaTime;
        if (transform.position.y < -5) Destroy(gameObject);
    }
}
