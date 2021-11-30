using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLateral : MonoBehaviour
{
    public float speed = 30f;
    private float Lim = 20f;

  
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        if (transform.position.x > Lim)
        {
            Destroy(gameObject);
        }

    }
}
