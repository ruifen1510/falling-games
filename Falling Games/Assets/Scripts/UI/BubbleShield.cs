using UnityEngine;
using UnityEngine.UI;

public class BubbleShield : MonoBehaviour
{
    public static Image shieldBar;
    public static float shield;
    
    [SerializeField] private float fillSpeed;
    [SerializeField] private Image bubbleShieldSelector;
    [SerializeField] private Color bubbleShieldColor;


    void Start()
    {
        shieldBar = GetComponent<Image>();
        shield = 0f;
        shieldBar.fillAmount = shield;

        bubbleShieldColor.a = 0.5f;

    }

    void Update()
    {
        shieldBar.fillAmount = shieldBar.fillAmount + shield + fillSpeed * Time.deltaTime;
    }

    public static void Reset()
    {
        if (shieldBar.fillAmount == 1f)
        shieldBar.fillAmount = 0f;
    }
}
