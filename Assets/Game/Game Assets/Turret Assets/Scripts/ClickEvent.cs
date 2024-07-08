using UnityEngine;
using UnityEngine.EventSystems;

public class ClickEvent : MonoBehaviour, IPointerDownHandler
{
    TurretHandling turretHandling;
    public GameObject character;
    CharacterActions characterActions;
    public void OnPointerDown(PointerEventData eventData)
    {

        if (!characterActions.bMovementGoing)
            characterActions.SetWalkLocation(turretHandling.CharacterShootingTransform);

        Debug.Log("check");

        characterActions.targetTurret = turretHandling;
    }

    private void Start()
    {
        turretHandling = gameObject.GetComponent<TurretHandling>();
        characterActions = character.GetComponent<CharacterActions>();
    }

}
