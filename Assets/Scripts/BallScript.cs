// /* BallScript for the popular pong game */


using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float maxInitialAngle = 0.67f;
    public float moveSpeed = 5f;

    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
        InitialPush();
    }

    private void InitialPush()
    {
        var x = Random.Range(-1,1);
        Debug.Log($"{x.ToString()} is the random value");
        Vector2 dir = x == -1 ? Vector2.left : Vector2.right;
        dir.y = Random.Range(-maxInitialAngle, maxInitialAngle);
        rb2d.linearVelocity = dir.normalized * moveSpeed;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            // Bereken nieuwe richtingsvector afhankelijk van waar op paddle geraakt is
            float y = (transform.position.y - collision.transform.position.y) / collision.collider.bounds.size.y;
            Vector2 dir = new Vector2(rb2d.linearVelocity.x > 0 ? 1 : -1, y).normalized;
            rb2d.linearVelocity = dir * moveSpeed;

            // Optioneel: verhoog snelheid lichtjes bij elke paddle hit
            moveSpeed *= 1.05f;
            
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            // Bij walls laat physics standaard rebound gebeuren
        }
    }

    public void ResetBall()
    {
        rb2d.linearVelocity = Vector2.zero;
        transform.position = initialPosition;
        InitialPush();
    }
}
