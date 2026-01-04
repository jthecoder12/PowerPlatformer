using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveCredits : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("GoBackToMainScreen", 13);
    }

    private void GoBackToMainScreen()
    {
        SceneManager.LoadScene(0);
    }
}
