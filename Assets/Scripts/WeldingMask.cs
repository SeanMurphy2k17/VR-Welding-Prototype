using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class WeldingMask : MonoBehaviour
{
    
    public void Welding(bool welding)
    {
        if(welding)
        {
            Bloom bloomLayer = null;
            GetComponent<PostProcessVolume>().profile.TryGetSettings(out bloomLayer);
            bloomLayer.intensity.value = 75;
        }
        else
        {
            Bloom bloomLayer = null;
            GetComponent<PostProcessVolume>().profile.TryGetSettings(out bloomLayer);
            bloomLayer.intensity.value = 0.5f;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
