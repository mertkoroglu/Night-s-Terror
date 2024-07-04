using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterActions : MonoBehaviour
{
    public Rigidbody rb;
    Vector3 movement;
    Transform walkLocation;
    public bool bMovementGoing = false;
    float walkSpeed = 9F;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    public void SetWalkLocation(Transform loc)
    {
        walkLocation = loc;
    }

    // Update is called once per frame
    void Update()
    {
        if (walkLocation != null && walkLocation.position != gameObject.transform.position)
        {
            bMovementGoing = true;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, walkLocation.position, walkSpeed * Time.deltaTime);
        }
        else
        {
            bMovementGoing=false;
        }
    }
}
