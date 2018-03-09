using UnityEngine;

public class PaddleController : MonoBehaviour {
    const float fieldUnits = 16f;
    const float paddleWidth = 1f;
    const float paddleHalfWidth = paddleWidth / 2f;
    const float minMouseX = paddleHalfWidth;
    const float maxMouseX = fieldUnits - paddleHalfWidth;

    void Update() {
        float mosuePos = fieldUnits * Input.mousePosition.x / Screen.width;
        mosuePos = Mathf.Clamp(mosuePos, minMouseX, maxMouseX);
        transform.position = new Vector3(mosuePos, transform.position.y, transform.position.z);
    }
}
