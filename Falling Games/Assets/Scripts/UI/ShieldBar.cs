using UnityEngine;
using UnityEngine.UI;

//STAMINA BAR (BLUE BAR)

public class ShieldBar : MonoBehaviour
{
    public static Image staminaBar;
    public static float stamina;

    private float maxStamina;

    [SerializeField] private float fillSpeed;

    void Start()
    {
        maxStamina = 100f;
        staminaBar = GetComponent<Image>();
        stamina = maxStamina;

        InvokeRepeating("Recharge", 0.0f, 1f);
    }

    private void Update()
    {
        ReduceShieldBar();
    }

    void ReduceShieldBar()
    {
        staminaBar.fillAmount = stamina / maxStamina;
    }

    void Recharge()
    {
        if(stamina < maxStamina)
        {
            stamina += 1f;
        }
    }
}
