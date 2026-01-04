using UnityEngine;

public class TogglePause : MonoBehaviour
{
    [SerializeField]
    private GameObject losePanel;

    [SerializeField]
    private GameObject pauseMenu;

    public void TogglePauseA()
    {
        if (!losePanel.activeInHierarchy)
        {
            Time.timeScale = pauseMenu.activeInHierarchy ? 1 : 0;
            pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
        }
    }
}
