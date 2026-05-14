using UnityEngine;
using TMPro;

public class HealthCounter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI healthText;

    [SerializeField]
    private PlayerData playerData;

    [SerializeField]
    private VoidEventChannel onPlayerTakeDamage;

    private void OnEnable()
    {
        if (onPlayerTakeDamage != null)
            onPlayerTakeDamage.OnEventRaised += UpdateHealthText;
            
        UpdateHealthText();
    }

    private void Start()
    {
        UpdateHealthText();
    }

    private void OnDisable()
    {
        if (onPlayerTakeDamage != null)
            onPlayerTakeDamage.OnEventRaised -= UpdateHealthText;
    }

    private void UpdateHealthText()
    {
        if (healthText != null && playerData != null)
        {
            healthText.text = Mathf.RoundToInt(playerData.currentHealth) + " / " + Mathf.RoundToInt(playerData.maxHealth);
        }
    }
}