using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator != null)
        {
            animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        }
    }

    public void SetIsMoving(bool val)
    {
        animator.SetBool("isMoving", val);
    }


    public void PlayButtonAnim()
    {
        animator.SetTrigger("PlayPressButtonAnim");
    }

    public void PlayDeathAnim()
    {
        animator.SetTrigger("PlayDeath");
    }
}
