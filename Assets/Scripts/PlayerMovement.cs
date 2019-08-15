using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float _speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private float getMovementSpeed(float input)
    {
        return input * _speed * Time.deltaTime;
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput != 0 || verticalInput != 0)
        {
            Vector3 movement = new Vector3(getMovementSpeed(horizontalInput), 
                0, 
                getMovementSpeed(verticalInput));
            transform.Translate(movement);
        }
    }
}
