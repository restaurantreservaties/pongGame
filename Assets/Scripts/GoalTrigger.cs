using UnityEditor.U2D.Aseprite;
using UnityEngine;


public class GoalTrigger : MonoBehaviour
{
    public bool isPlayerGoal = false; // Zet false voor rechter zone, true voor linker
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = Object.FindFirstObjectByType<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(ScoreManager.Ball))
        {
            if (isPlayerGoal)
            {
                scoreManager.PlayerScored(); // Bal in rechter zone = speler punt
            }
            else
            {
                scoreManager.EnemyScored(); // Bal in linker zone = tegenstander punt
            }

            // Reset de bal positie
            BallScript ball = other.GetComponent<BallScript>();
            ball.ResetBall();
        }
    }
}

