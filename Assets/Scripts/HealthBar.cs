using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private Gradient gradient;
    [SerializeField] private PlayerData playerData; 

    void Update()
    {
        if (fillImage != null && playerData != null)
        {
            SetHealth();
        }
    }

    private void SetHealth()
    {
        if (playerData.maxHealth <= 0) return;

        float healthNormalized = (float)playerData.currentHealth / playerData.maxHealth;

        fillImage.fillAmount = healthNormalized;

        if (gradient != null)
        {
            fillImage.color = gradient.Evaluate(healthNormalized);
        }
    }
}