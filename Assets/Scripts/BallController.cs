using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    public PaddleController paddle;
    public float launchSpeed = 10f;

    private bool launched;
    private Vector3 paddleToBall;

    void Start() {
        paddleToBall = transform.position - paddle.transform.position;
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    void Update() {
        // Until launch, ball follows paddle around.
        if (launched) return;
        transform.position = paddle.transform.position + paddleToBall;
        if (Input.GetMouseButtonDown(0)) {
            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.up * launchSpeed;
            launched = true;
        }

    }
}
