﻿using System;
using BeeGame.Interfaces;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Components
{
    public class Door : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform openPoint;
        [SerializeField] private TextMeshProUGUI counter;
        [SerializeField] private int requiredBees;

        private void Open()
        {
            counter.gameObject.SetActive(false);
            transform.DOLocalMoveY(openPoint.transform.position.y, 2f);
        }

        public void Interact(GameObject interacter)
        {
            requiredBees--;
            Destroy(interacter);
            if (requiredBees <= 0)
            {
                Open();
            }
        }

        private void Update()
        {
           counter.text = requiredBees.ToString();
        }
    }

}
