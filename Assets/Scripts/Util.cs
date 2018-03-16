using UnityEngine;
using System.Collections;

public class Util {
    public const float fieldWidth = 16f;
    public const float fieldHeight = 12f;
    public const float paddleWidth = 1.5f;
    public const float vfxZ = -9f;

    public readonly static Vector2 centerField = new Vector2(fieldWidth / 2f, fieldHeight / 2f);

    private static ContactPoint2D[] contactPointTemp = new ContactPoint2D[1];

    public static float XPositionToStereoPan(Vector3 position) {
        return XPositionToStereoPan(position.x);
    }
    public static float XPositionToStereoPan(Vector2 position) {
        return XPositionToStereoPan(position.x);
    }

    public static float XPositionToStereoPan(float x) {
        return (2f * x / fieldWidth) - 1.0f;
    }

    public static bool FirstCollisionPoint(Collision2D collision, out Vector2 point) {
        if (collision.GetContacts(contactPointTemp) >= 1) {
            point = contactPointTemp[0].point;
            return true;
        } else {
            point = Vector2.zero;
            return false;
        }
    }
}
