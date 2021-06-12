using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : MonoBehaviour
{
    [SerializeField] private float requiredPollen;

    private void Awake()
    {
        GameManager.Instance.RequiredPollen = requiredPollen;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (GameManager.Instance.Pollen < requiredPollen)
            {
                Debug.Log("Idiot");
            }
            else
            {
                Debug.Log("Nice!");
            }
        }
    }
}
