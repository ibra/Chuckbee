using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Queen : MonoBehaviour
{
    [SerializeField] private float requiredPollen;
    [SerializeField] private GameObject epicPanel;

    private void Awake()
    {
        GameManager.Instance.RequiredPollen = requiredPollen;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (GameManager.Instance.Nectar < requiredPollen)
            {
                Debug.Log("Idiot");
            }
            else
            {
                epicPanel.SetActive(true);
                TextMeshProUGUI nectarText = epicPanel.transform.Find("nectarAmount").GetComponent<TextMeshProUGUI>();
                nectarText.text =
                    $"<color=yellow>{GameManager.Instance.Nectar}ml</color> of nectar!";
                
                Time.timeScale = 0f; //if shit doesnt work its probably because of this
            }
        }
    }
}
