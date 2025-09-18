using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Om scene te herstarten

public class ScoreManager : MonoBehaviour
{
    public static int playerScore = 0;
    public static int enemyScore = 0;
    public const string Ball = "Ball";
    public const string PlayerPaddle = "PlayerPaddle";
    public const string EnemyPaddle = "EnemyPaddle";
    public const string Paddle = "Paddle";
    public const string Wall = "Wall";

    public void PlayerScored()
    {
        playerScore++;
        Debug.Log("Player scored! Score: " + playerScore);
        ResetBall();
        IncreaseSize(ScoreManager.PlayerPaddle);
        DecreaseSize(ScoreManager.EnemyPaddle);
    }

    public void EnemyScored()
    {
        enemyScore++;
        Debug.Log("Enemy scored! Score: " + enemyScore);
        ResetBall();
        IncreaseSize(ScoreManager.EnemyPaddle);
        DecreaseSize(ScoreManager.PlayerPaddle);
    }

    void ResetBall()
    {
        GameObject ball = GameObject.FindGameObjectWithTag(ScoreManager.Ball);
        if (ball != null)
        {
            ball.transform.position = Vector3.zero;
            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                float angle = Random.Range(-45, 45);
                if (Random.value < 0.5f) angle += 180;
                Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;
                rb.AddForce(direction * 300); // Pas de kracht aan indien nodig
            }
        }
    }

    void IncreaseSize(string tag)
    {
        GameObject paddle = GameObject.FindGameObjectWithTag(tag);
        if (paddle != null)
        {
            Vector3 newScale = paddle.transform.localScale;
            newScale.y += 0.5f; // Verhoog de hoogte van de paddle
            paddle.transform.localScale = newScale;
            Debug.Log(tag + " paddle size increased!");
        }
    }

    void DecreaseSize(string tag)
    {
        GameObject paddle = GameObject.FindGameObjectWithTag(tag);
        if (paddle != null)
        {
            Vector3 newScale = paddle.transform.localScale;
            newScale.y = Mathf.Max(1f, newScale.y - 0.5f); // Verlaag de hoogte van de paddle, minimum 1f
            paddle.transform.localScale = newScale;
            Debug.Log(tag + " paddle size decreased!");
        }
    }
}
