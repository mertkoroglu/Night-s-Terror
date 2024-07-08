using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterActions : MonoBehaviour
{
    public Rigidbody rb;
    Vector3 movement;
    public Transform walkLocation = null;
    public bool bMovementGoing = false;
    float walkSpeed = 9F;

    float dieTimer = 3F;
    bool bIsDying = false;

    private float unscaledDeltaTime;
    private float lastRealTime;

    public AudioSource src;
    public AudioClip deathSound;

    public TurretHandling targetTurret;
    CharacterAnim anim;


    // Start is called before the first frame update
    void Start()
    {
        lastRealTime = Time.realtimeSinceStartup;
        anim = gameObject.GetComponent<CharacterAnim>();

    }

    public void SetWalkLocation(Transform loc)
    {
        walkLocation = loc;
    }

    public void PlayButtonAnim()
    {
        anim.PlayButtonAnim();
    }

    public void Die()
    {
        //Destroy(character);
        Time.timeScale = 0;
        bIsDying = true;
        src.clip = deathSound;
        src.Play();
        anim.PlayDeathAnim();
    }

    // Update is called once per frame
    void Update()
    {
        unscaledDeltaTime = Time.realtimeSinceStartup - lastRealTime;
        lastRealTime = Time.realtimeSinceStartup;

        if (walkLocation != null && walkLocation.position != gameObject.transform.position)
        {
            bMovementGoing = true;
            anim.SetIsMoving(true);

            // Move towards the walk location
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, walkLocation.position, walkSpeed * Time.deltaTime);

            // Rotate towards the walk location
            Vector3 direction = (walkLocation.position - gameObject.transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, lookRotation, Time.deltaTime * walkSpeed);
        }
        else if (walkLocation != null && walkLocation.position == gameObject.transform.position)
        {
            bMovementGoing = false;
            anim.SetIsMoving(false);
            anim.PlayButtonAnim();
            walkLocation = null;
            targetTurret.ChangeTurretState();
        }

        if (bIsDying)
        {
            dieTimer -= unscaledDeltaTime;
            if (dieTimer <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                bIsDying = false;
                Time.timeScale = 1F;
            }
        }
    }
}
