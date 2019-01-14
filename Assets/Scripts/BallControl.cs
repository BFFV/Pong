using UnityEngine;

public class BallControl : MonoBehaviour {

    Rigidbody2D rb2d;

    // Initial direction for the ball
    void StartBall() {
        float direction = Random.Range(0, 4);
        if (direction < 1) {
            rb2d.AddForce(new Vector2(-20, -15));
        }
        else if (direction < 2) {
            rb2d.AddForce(new Vector2(20, -15));
        }
        else if (direction < 3) {
            rb2d.AddForce(new Vector2(-20, 15));
        }
        else {
            rb2d.AddForce(new Vector2(20, 15));
        }
    }

    // Initialize ball movement
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("StartBall", 2);
    }

    // Reset ball
    void ResetBall() {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    // Restart game
    void RestartGame() {
        ResetBall();
        Invoke("StartBall", 1);
    }

    // Ball collision
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel;
        }
    }
}
