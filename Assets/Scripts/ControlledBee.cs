using System;
using UnityEngine;

public class ControlledBee : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;
    
    private BeeMovement _beeMovement;
    private bool _isControlled;
    


    private void Update()
    {
        if (_isControlled)
        {
            Vector3 lookAt = _beeMovement.transform.position;
            lookAt.y = transform.position.y;
            transform.LookAt(lookAt);
            
            if (Vector3.Distance(transform.position, _beeMovement.transform.position) >= MinDist)
            {
                transform.forward * (moveSpeed * Time.deltaTime);


                if (Vector3.Distance(transform.position, _beeMovement.transform.position) <= MaxDist)
                {
                    // Epic Stuff(?)
                }

            }
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (_isControlled) return;
            _beeMovement = other.GetComponent<BeeMovement>();
            _beeMovement.ControlledBees.Add(this);
            _isControlled = true;
        }
    }
}
