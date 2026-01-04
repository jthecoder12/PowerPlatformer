using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Text powerText;
    private bool canJump = false;
    public static uint power = 1000;

    [SerializeField]
    private GameObject losePanel;

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpHeight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        powerText = GameObject.FindGameObjectWithTag("PowerText").GetComponent<Text>();
    }

    private void Update()
    {
        powerText.text = $"Power: {power / 10}%";

        if (Input.GetKeyDown(KeyCode.W) && canJump && power > 0) power -= 10;
        if (Input.GetKeyDown(KeyCode.Escape) && !losePanel.activeInHierarchy)
        {
            Time.timeScale = pauseMenu.activeInHierarchy ? 1 : 0;
            pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
        }

        if (power <= 0)
        {
            pauseMenu.SetActive(false);
            losePanel.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if ((Input.GetKey(KeyCode.A) || MovementButton.leftheld) && power > 0)
        {
            rb.AddForceX(-speed * Time.fixedDeltaTime, ForceMode2D.Force);
            power -= 1;
        }
        if ((Input.GetKey(KeyCode.D) || MovementButton.rightheld) && power > 0)
        {
            rb.AddForceX(speed * Time.fixedDeltaTime, ForceMode2D.Force);
            power -= 1;
        }
        if ((Input.GetKey(KeyCode.W) || MovementButton.upheld) && canJump && power > 0) rb.AddForceY(jumpHeight * Time.fixedDeltaTime, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform")) canJump = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform")) canJump = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Recharge") && !losePanel.activeInHierarchy)
        {
            GetComponent<AudioSource>().Play();
            power = 1000;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("key"))
        {
            Destroy(GameObject.FindGameObjectWithTag("door"));
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Finish") && SceneManager.GetActiveScene().buildIndex + 1 != SceneManager.sceneCountInBuildSettings && !losePanel.activeInHierarchy) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
