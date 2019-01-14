using UnityEngine;

public class SideWalls : MonoBehaviour {

    // Detect Scoring
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.name == "Ball") {
            string wallName = transform.name;
            GameManager.Score(wallName);
            collider.gameObject.SendMessage("RestartGame", 1.0f, SendMessageOptions.RequireReceiver);
        }
    }
}
