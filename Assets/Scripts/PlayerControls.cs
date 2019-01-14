using UnityEngine;

public class PlayerControls : MonoBehaviour {

    KeyCode moveUp = KeyCode.UpArrow;
    KeyCode moveDown = KeyCode.DownArrow;
    float speed = 10.0f;
    float boundY = 2.25f;
    Rigidbody2D rb2d;

    // Initialize paddle physics and controls
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        if (name == "PlayerPaddle1") {
            moveUp = KeyCode.W;
            moveDown = KeyCode.S;
        }
    }

    // Check and process inputs
    void Update() {
        var vel = rb2d.velocity;
        if (Input.GetKey(moveUp)) {
            vel.y = speed;
        }
        else if (Input.GetKey(moveDown)) {
            vel.y = -speed;
        }
        else {
            vel.y = 0;
        }
        rb2d.velocity = vel;
        var pos = transform.position;
        if (pos.y > boundY) {
            pos.y = boundY;
        }
        else if (pos.y < -boundY) {
            pos.y = -boundY;
        }
        transform.position = pos;
    }
}
