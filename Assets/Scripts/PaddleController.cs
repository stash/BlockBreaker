using UnityEngine;

public class PaddleController : MonoBehaviour {
    public bool autoPlay = false;

    BallController ball;

    const float fieldUnits = 16f;
    const float paddleWidth = 1f;
    const float paddleHalfWidth = paddleWidth / 2f;
    const float minMouseX = paddleHalfWidth;
    const float maxMouseX = fieldUnits - paddleHalfWidth;

    void Start() {
        ball = FindObjectOfType<BallController>();
    }

    void Update() {
        float x;
        if (autoPlay) {
            x = ball.transform.position.x;
        } else {
            x = fieldUnits * Input.mousePosition.x / Screen.width;
        }
        MoveToX(x);
    }

    void MoveToX(float x) {
        x = Mathf.Clamp(x, minMouseX, maxMouseX);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
