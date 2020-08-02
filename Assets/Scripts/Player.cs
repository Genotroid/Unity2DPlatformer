using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction OnTakeDiamond;

    public void TakeDiamond()
    {
        OnTakeDiamond?.Invoke();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
