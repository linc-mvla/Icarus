using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    [SerializeField] Light DirectionalLight;
    [SerializeField] LightingPreset Preset;
    [SerializeField, Range(0, 24)] float TimeOfDay;
    // Start is called before the first frame update

    private void OnValidate()
    {
        if (DirectionalLight != null) {
            return;
        }

        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights) {
                if (light.type == LightType.Directional) {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
