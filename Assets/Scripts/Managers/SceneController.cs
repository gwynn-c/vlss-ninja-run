using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void QuitGame() => Application.Quit();
    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}