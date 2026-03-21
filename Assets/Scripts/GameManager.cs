using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static event Action<int> OnHealthChanged;

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

        OnHealthChanged?.Invoke(currentHearts);
    }

    public void addKey()
    {
        currentKeys++;
        keys[currentKeys - 1].sprite = fullKeySprite;
    }

    public void removeHealth()
    {
        currentHearts--;

        if (currentHearts < 0)
        {
            currentHearts = 0;
            // OnHealthChanged?.Invoke(currentHearts);
            return;
            // Application.Quit();
        }

        hearts[currentHearts].sprite = shallowHeartSprite;
        OnHealthChanged?.Invoke(currentHearts);
    }
}
