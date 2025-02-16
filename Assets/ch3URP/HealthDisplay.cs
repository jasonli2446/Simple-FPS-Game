using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    public PlayerCharacter player;
    private TextMeshProUGUI _healthText;

    void Start()
    {
        _healthText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (_healthText != null && player != null)
        {
            int health = player.GetHealth();
            _healthText.text = health + ": " + new string('*', health);
        }
    }
}