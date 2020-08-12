using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction DiamondTaked;

    public void TakeDiamond()
    {
        DiamondTaked?.Invoke();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
