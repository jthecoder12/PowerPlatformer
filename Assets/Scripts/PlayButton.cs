using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    [SerializeField]
    private GameObject losePanel;

    public void Play()
    {
        SceneManager.LoadScene(2);
    }

    public void Credits()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        Movement.power = 1000;
        try
        {
            losePanel?.SetActive(false);
        }
        catch (UnassignedReferenceException) { }
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        Movement.power = 1000;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Instructions()
    {
        SceneManager.LoadScene(1);
    }
}
