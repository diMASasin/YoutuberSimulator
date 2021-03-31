using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Message : MonoBehaviour
{
    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
