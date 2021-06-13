﻿using System;
using BeeGame.Interfaces;
using UnityEngine;

namespace BeeGame
{
    public class BeeBullet : MonoBehaviour
    {
        public void ShootBullet(Transform shootPoint, float shootForce, float destroyTime)
        {
            Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.isKinematic = false;
            rigidbody.AddForce(new Vector2(shootForce,0), ForceMode2D.Impulse);
            
            transform.parent = null;
            Destroy(gameObject, destroyTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == 8 )
            {
                other.GetComponent<IInteractable>().Interact(gameObject);
            }
        }

    }
}
