using System;
using DG.Tweening;
using UnityEngine;

namespace Components
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Transform openPoint;

        public void Open()
        {
            transform.DOLocalMoveY(openPoint.transform.position.y, 2f);
        }
    }

}
