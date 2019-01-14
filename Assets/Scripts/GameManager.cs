using UnityEngine;

public class GameManager : MonoBehaviour {

    static int PlayerScore1 = 0;
    static int PlayerScore2 = 0;
    public GUISkin layout;
    GameObject ball;

    // Find ball object
    void Start() {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    // Player scores
    public static void Score(string wallID) {
        if (wallID == "RightWall") {
            PlayerScore1++;
        }
        else {
            PlayerScore2++;
        }
    }

    // GUI
    void OnGUI() {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);
        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART")) {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            ball.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }
        if (PlayerScore1 == 10) {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER 1 WINS!!!");
            ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        else if (PlayerScore2 == 10) {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER 2 WINS!!!");
            ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }
}
