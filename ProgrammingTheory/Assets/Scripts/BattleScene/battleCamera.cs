using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleCamera : MonoBehaviour
{
    public Vector3 circleCharacterOffset = new Vector3(10, 5, 0);
    public float rotationSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CircleCharacter(GameObject character)
    {
        transform.position = character.transform.position;
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
