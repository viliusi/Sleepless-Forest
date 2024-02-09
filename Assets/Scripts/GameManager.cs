using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Volume Volume;
    public float Insomnia = 0f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetVisualEffects()
    {
        // Normalize insomnia value to range 0-1
        float normalizedInsomnia = Insomnia / 1000f;

        // Get references to the effects
        ChromaticAberration chromaticAberration;
        Vignette vignette;
        LensDistortion lensDistortion;
        FilmGrain filmGrain;
        DepthOfField depthOfField;
        WhiteBalance whiteBalance;
        ColorAdjustments colorAdjustments;

        if (Volume.profile.TryGet(out chromaticAberration))
        {
            chromaticAberration.intensity.value = normalizedInsomnia;
        }

        if (volume.profile.TryGet(out vignette))
        {
            vignette.intensity.value = normalizedInsomnia;
        }

        if (volume.profile.TryGet(out lensDistortion))
        {
            lensDistortion.intensity.value = normalizedInsomnia * 100; // Assuming you want a larger effect for lens distortion
        }

        if (volume.profile.TryGet(out filmGrain))
        {
            filmGrain.intensity.value = normalizedInsomnia;
        }

        if (volume.profile.TryGet(out depthOfField))
        {
            depthOfField.focusDistance.value = normalizedInsomnia * 10; // Assuming you want a larger effect for depth of field
        }

        if (volume.profile.TryGet(out whiteBalance))
        {
            whiteBalance.temperature.value = normalizedInsomnia * 100; // Assuming you want a larger effect for white balance
        }

        if (volume.profile.TryGet(out colorAdjustments))
        {
            colorAdjustments.saturation.value = normalizedInsomnia * 100; // Assuming you want a larger effect for color adjustments
        }

    }
}
