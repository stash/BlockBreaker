using UnityEngine;

public class BallController : MonoBehaviour {
    public Vector2 launchVelocity = new Vector2(1f, 10f);
    public float tweakMagnitude = 0.2f;
    public GameObject explodeVFX;

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
        SceneController.OnDeath += SceneController_OnDeath;
    }

    void OnDestroy() {
        ending = true;
        SceneController.OnSceneEnding -= SceneController_OnSceneEnding;
        SceneController.OnDeath -= SceneController_OnDeath;
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

    public void TweakVelocity(Vector2 tweak) {
        if (ending) return;
        rb.velocity += tweak;
    }


    void SceneController_OnSceneEnding() {
        ending = true;
        // Stop the ball if the scene is ending
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
    }

    void SceneController_OnDeath() {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, Util.vfxZ);
        GameObject.Instantiate(explodeVFX, position, Quaternion.identity);
    }
}
