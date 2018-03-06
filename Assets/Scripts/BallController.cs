using UnityEngine;

public class BallController : MonoBehaviour {
    public Vector2 launchVelocity = new Vector2(1f, 10f);

    private PaddleController paddle;
    private bool launched;
    private Vector3 paddleToBall;

    void Start() {
        paddle = FindObjectOfType<PaddleController>(); // find active paddle

        paddleToBall = transform.position - paddle.transform.position;
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    void Update() {
        // Until launch, ball follows paddle around.
        if (launched) return;

        transform.position = paddle.transform.position + paddleToBall;

        if (Input.GetMouseButtonDown(0)) {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            // launch and relinquish control to physics subsystem
            rb.isKinematic = false;
            rb.velocity = launchVelocity;
            launched = true;
        }
    }
}
