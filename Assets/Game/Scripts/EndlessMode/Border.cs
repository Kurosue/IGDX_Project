using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        Debug.Log(other);
        Destroy(other.gameObject);
    }
}
