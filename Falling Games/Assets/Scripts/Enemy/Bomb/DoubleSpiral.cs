using System.Collections;
using UnityEngine;

public class DoubleSpiral : MonoBehaviour
{
    private float angle = 0f;
    private Vector2 bulletMoveDir;

    [SerializeField] private float delayShootDuration = 2f;

    void Start()
    {
        StartCoroutine(DelayShoot());
    }

    IEnumerator DelayShoot()
    {
        yield return new WaitForSeconds(delayShootDuration);
        InvokeRepeating("Fire1", 0f, 0.2f);
    }

    private void Fire1()
    {
        for (int i = 0; i<= 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle + 180f * i) * Mathf.PI / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle + 180f * i) * Mathf.PI / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = Enemy3rdBulletPool.instance3.GetPooledObjects();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

            angle += 10f;
            if(angle >= 360f)
            {
                angle = 0f;
            }
        }
    }
}
