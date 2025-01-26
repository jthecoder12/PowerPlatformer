using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void Restart()
    {
        Movement.power = 100;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
