using UnityEngine;
using UnityEngine.UI;

public class RedDamageEffect : MonoBehaviour
{
    public Material overlayMaterial;

    int currentHealth = 3;

    void OnEnable()
    {
        GameManager.OnHealthChanged += UpdateHealth;
    }

    void OnDisable()
    {
        GameManager.OnHealthChanged -= UpdateHealth;
    }

    void UpdateHealth(int health)
    {
        currentHealth = health;
    }

    void Update()
    {
        if (currentHealth == 0)
        {
            // float intensity = Mathf.Lerp(0.2f, 0.7f, Mathf.PingPong(Time.time, 1));

            float intensity = Mathf.PingPong(Time.time, 0.5f) + 0.2f;
            overlayMaterial.SetFloat("_Intensity", intensity);
        }
        else
        {
            overlayMaterial.SetFloat("_Intensity", 0);
        }
    }
}
