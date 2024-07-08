using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemClickEvent : MonoBehaviour, IPointerDownHandler
{
    EnergyHandling eh;
    // Start is called before the first frame update
    void Start()
    {
        eh = GameObject.FindWithTag("Energy").GetComponent<EnergyHandling>();
        if (eh != null ) 
            eh.PlaySound();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("works");
        //eh.PlaySound();
        if (eh != null)
        {
            eh.AddEnergy();
        }
        Destroy(gameObject);
    }

}
