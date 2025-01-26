using UnityEngine;

public class MusicController : MonoBehaviour
{
    private static bool created = false;

    private void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this);
            created = true;
        }
        else Destroy(gameObject);
    }
}
