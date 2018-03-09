using UnityEngine;

public class BallController : MonoBehaviour {
    public Vector2 launchVelocity = new Vector2(1f, 10f);
    public float tweakMagnitude = 0.2f;

    private PaddleController paddle;
    private bool launched;
    private bool ending;
    private Vector3 paddleToBall;
    private Rigidbody2D rb;

    void Start() {
        paddle = FindObjectOfType<PaddleController>(); // find active paddle

        paddleToBall = transform.position - paddle.transform.position;

        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

        ending = false;
        SceneController.OnSceneEnding += SceneController_OnSceneEnding;
    }

    void OnDestroy() {
        ending = true;
        SceneController.OnSceneEnding -= SceneController_OnSceneEnding;
    }

    void Update() {
        // Until launch, ball follows paddle around.
        if (launched) return;

        transform.position = paddle.transform.position + paddleToBall;

        if (Input.GetMouseButtonDown(0)) {
            // launch and relinquish control to physics subsystem
            rb.isKinematic = false;
            rb.velocity = launchVelocity;
            launched = true;
        }
    }

    void SceneController_OnSceneEnding() {
        ending = true;
        // Stop the ball if the scene is ending
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (ending) return;
        Vector2 tweak = new Vector2(
            Random.Range(-tweakMagnitude, tweakMagnitude), 
            Random.Range(-tweakMagnitude, tweakMagnitude)
        );
        rb.velocity += tweak;
    }
}
