using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {
    const float fieldUnits = 16f;
    const float paddleWidth = 1f;

	void Update () {
        float mosuePos = fieldUnits * Input.mousePosition.x / Screen.width;
        mosuePos = Mathf.Clamp(mosuePos, paddleWidth / 2, fieldUnits - paddleWidth / 2);
        transform.position = new Vector3(mosuePos, transform.position.y, transform.position.z);
	}
}
