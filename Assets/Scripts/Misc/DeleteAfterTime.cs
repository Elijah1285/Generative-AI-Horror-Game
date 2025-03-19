using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterTime : MonoBehaviour
{
    [SerializeField] float time_for_deletion;

    void Update()
    {
        time_for_deletion -= Time.deltaTime;

        if (time_for_deletion <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
