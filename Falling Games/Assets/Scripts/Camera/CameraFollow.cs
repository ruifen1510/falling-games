using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float t = 0.2f;

    void FixedUpdate()
    {
        Vector3 targetPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        transform.position = Vector3.Lerp(transform.position, targetPos, t);
    }
}
