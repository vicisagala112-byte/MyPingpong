using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    public void LaunchBall()
    {
        transform.position = Vector3.zero;

        float xDirection = Random.Range(0, 2) == 0 ? 1 : -1;
        float yDirection = Random.Range(-0.5f, 0.5f);

        Vector2 direction = new Vector2(xDirection, yDirection).normalized;

        rb.linearVelocity = direction * speed;
    }
}
