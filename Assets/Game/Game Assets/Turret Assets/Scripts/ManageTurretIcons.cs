using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageTurretIcons : MonoBehaviour
{
    public Camera cameraObj;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        SetSliderInvisible();
        SetIconInvisible();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cameraObj.transform);
        transform.Rotate(100, 0, 0); // Adjust this as necessary for correct facing


        slider.transform.LookAt(cameraObj.transform);
        slider.transform.Rotate(0, 0, 0);
    }

    public void SetIconInvisible()
    {
        transform.localScale = new Vector3(0, 0, 0);
    }

    public void SetIconVisible()
    {
        transform.localScale = new Vector3(0.15F, 0.15F, 0.15F);
    }

    public void SetSliderInvisible()
    {
        slider.transform.localScale = new Vector3(0, 0, 0);
    }

    public void SetSliderVisible()
    {
        slider.transform.localScale = new Vector3(1F, 1F, 1F);
    }

    public void SetSliderValue(float val)
    {
        slider.value = val;
    }
}
