using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int currentHearts = 3;
    public int currentKeys;

    public Canvas uiCanvas;

    public Sprite fullKeySprite;
    public Sprite shallowHeartSprite;

    public Transform keysLayout;
    public Transform heartsLayout;

    Image[] keys;
    Image[] hearts;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        keys = keysLayout.GetComponentsInChildren<Image>();
        hearts = heartsLayout.GetComponentsInChildren<Image>();
    }

    public void addKey()
    {
        Debug.Log("GameManager instance: " + instance);
        Debug.Log("Keys array: " + keys);
        Debug.Log("Keys length: " + (keys != null ? keys.Length.ToString() : "NULL"));
        Debug.Log("FullKey sprite: " + fullKeySprite);


        currentKeys++;

        keys[currentKeys - 1].sprite = fullKeySprite;
    }

    // Still Undone
    public void removeHealth()
    {
        currentHearts--;

        if (currentHearts < 0)
        {
            // Application.Quit();
        }

        hearts[currentHearts].sprite = shallowHeartSprite;
    }
}
