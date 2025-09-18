using UnityEngine;

public class Paddle1Controller : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveVelocity;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 newPos = rb.position + moveVelocity * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
    }

    public float moveSpeed = 10f;
    private float verticalInput;

    void Update()
    {
        verticalInput = 0f;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            verticalInput = 1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            verticalInput = -1f;
        }

        Vector3 move = new Vector3(0, verticalInput, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(move);

        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -4f, 4f); 
        transform.position = pos;
    }
}
