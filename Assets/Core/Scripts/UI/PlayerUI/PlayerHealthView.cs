using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthView : MonoBehaviour
{
    [SerializeField] private Image HealthBarFront;

    private void Awake()
    {
        HealthBarFront = GetComponent<Image>();
    }

    public void UpdateUI(float current, float max)
    {
        HealthBarFront.fillAmount = current / max;
    }
}