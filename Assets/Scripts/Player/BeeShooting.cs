using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using BeeGame;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BeeShooting : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootForce = 25f;
    
    private BeeMovement _beeMovement;
    private bool _positionOccupied;

    private ControlledBee _controlledBee;

    private void Start()
    {
        _beeMovement = GetComponent<BeeMovement>();
    }

    private void Update()
    {
        if (_beeMovement.ControlledBees.Count == 0 && _positionOccupied == false) return; 
        
        if (Input.GetMouseButtonDown(0) && !_positionOccupied)
        {
            _controlledBee = _beeMovement.ControlledBees[Random.Range(0, _beeMovement.ControlledBees.Count)];
            
            _beeMovement.ControlledBees.Remove(_controlledBee);
            
            _controlledBee.enabled = false;
            _controlledBee.GetComponent<Rigidbody2D>().isKinematic = true;

            _controlledBee.transform.position = shootPoint.transform.position;
            _controlledBee.transform.eulerAngles = shootPoint.eulerAngles;    
            _controlledBee.transform.parent = shootPoint.transform;
            
            _positionOccupied = true;

        }
        else if (Input.GetMouseButtonDown(0) && _positionOccupied)
        {
            BeeBullet bulletInstance = _controlledBee.gameObject.AddComponent<BeeBullet>();
            bulletInstance.enabled = true;
            bulletInstance.ShootBullet(shootPoint, shootForce, 5f); ;
            _positionOccupied = false;
        }

    }
}
