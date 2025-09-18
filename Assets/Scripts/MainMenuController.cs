using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Pong"); // Vervang "Level1" door de naam van je gameplay-scène
    }
}
