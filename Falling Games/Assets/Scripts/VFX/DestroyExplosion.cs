using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyExplosion : MonoBehaviour
{
    //added to animation
    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
