using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void SetIsMoving(bool val)
    {
        animator.SetBool("isMoving", val);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
