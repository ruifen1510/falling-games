using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    [SerializeField] private float shieldDamageAmount = 15f;
    [SerializeField] private int damageAmt = 1;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && PlayerController.isShieldActive == false)
        {
            if (ShieldBar.stamina > 0f)
            {
                ShieldBar.stamina -= shieldDamageAmount;
            }
            else
            {
                HealthBar.health -= damageAmt;
            }
        }
    }
}
