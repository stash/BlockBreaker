using UnityEngine;
using System.Collections;

public class Util {
    public const float fieldWidth = 16f;
    public const float paddleWidth = 1.5f;

    public static float XPositionToStereoPan(Vector3 position) {
        return XPositionToStereoPan(position.x);
    }
    public static float XPositionToStereoPan(Vector2 position) {
        return XPositionToStereoPan(position.x);
    }

    public static float XPositionToStereoPan(float x) {
        return (2f * x / fieldWidth) - 1.0f;
    }
}
