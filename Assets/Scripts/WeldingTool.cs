using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeldingTool : MonoBehaviour
{
    [SerializeField]
    private GameObject WelderTip;
    [SerializeField]
    private GameObject ParticleSystem_;
    [SerializeField]
    private GameObject WeldingLight;

    public bool Contact;
    public bool FlowingCurrent;

    public GameObject MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            FlowingCurrent = true;
        }
        else
        {
            FlowingCurrent = false;
        }
        if(FlowingCurrent && Contact)
        {
            StartWeld();
        }
        else
        {
            StopWeld();
        }
    }
    void StartWeld()
    {
        if (ParticleSystem_.GetComponent<ParticleSystem>().isStopped)
        {
            WeldingLight.SetActive(true);
            ParticleSystem_.GetComponent<ParticleSystem>().Play();
            Debug.Log("Start Welding");
            MainCamera.GetComponent<WeldingMask>().Welding(true);
        }
    }
    void StopWeld()
    {
        if (ParticleSystem_.GetComponent<ParticleSystem>().isPlaying)
        {
            WeldingLight.SetActive(false);
            ParticleSystem_.GetComponent<ParticleSystem>().Stop();
            Debug.Log("Stop Welding");
            MainCamera.GetComponent<WeldingMask>().Welding(false);
        }
    }
    void FixedUpdate()
    {
        StrikeArk();
    }
    void StrikeArk()
    {
        float RayDistance = 0.01f;
        RaycastHit Hit;
        if (Contact)
        {
            Debug.DrawLine(WelderTip.transform.position, WelderTip.transform.position + (WelderTip.transform.forward * RayDistance), Color.red);
        }
        else
        {
            Debug.DrawLine(WelderTip.transform.position, WelderTip.transform.position + (WelderTip.transform.forward * RayDistance), Color.green);
        }
        if(Physics.Raycast(WelderTip.transform.position, WelderTip.transform.forward, RayDistance))
        {
            Contact = true;
        }
        else
        {
            Contact = false;
        }
    }
}
