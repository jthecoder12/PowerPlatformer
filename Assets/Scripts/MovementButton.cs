using UnityEngine;
using UnityEngine.EventSystems;

public class MovementButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private string direction;

    public static bool upheld = false;
    public static bool leftheld = false;
    public static bool rightheld = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        switch(direction)
        {
            case "right":
                rightheld = true;
                break;
            case "left":
                leftheld = true;
                break;
            case "up":
                upheld = true;
                break;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        switch (direction)
        {
            case "right":
                rightheld = false;
                break;
            case "left":
                leftheld = false;
                break;
            case "up":
                upheld = false;
                break;
        }
    }
}
