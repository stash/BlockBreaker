using UnityEngine;
using System.Collections;

public class Util {
    public const float fieldWidth = 16f;
    public const float paddleWidth = 1.5f;
    public const float vfxZ = -9f;

    public static float XPositionToStereoPan(Vector3 position) {
        return XPositionToStereoPan(position.x);
    }
    public static float XPositionToStereoPan(Vector2 position) {
        return XPositionToStereoPan(position.x);
    }

    public static float XPositionToStereoPan(float x) {
        return (2f * x / fieldWidth) - 1.0f;
    }

    public static Vector2 V3to2(Vector3 v3) {
        return new Vector2(v3.x, v3.y);
    }
}
