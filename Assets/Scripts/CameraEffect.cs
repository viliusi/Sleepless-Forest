using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraEffect : MonoBehaviour
{
    public Volume volume;
    public ChromaticAberration chromaticAberration;
    public Vignette vignette;
    public LensDistortion lensDistortion;
    public FilmGrain filmGrain;
    public DepthOfField depthOfField;
    public WhiteBalance whiteBalance;
    public ColorAdjustments colorAdjustments;

    public PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGet(out chromaticAberration);
        volume.profile.TryGet(out vignette);
        volume.profile.TryGet(out lensDistortion);
        volume.profile.TryGet(out filmGrain);
        volume.profile.TryGet(out depthOfField);
        volume.profile.TryGet(out whiteBalance);
        volume.profile.TryGet(out colorAdjustments);
    }

    // Update is called once per frame
    void Update()
    {
        chromaticAberration.intensity.value = playerStats.insomnia * 100f;
        vignette.intensity.value = playerStats.insomnia / 2f;
        lensDistortion.intensity.value = 0.5f + playerStats.insomnia / 10f;
        lensDistortion.scale.value = 1f - playerStats.insomnia / 5f;
        filmGrain.intensity.value = playerStats.insomnia;
        depthOfField.focusDistance.value = playerStats.insomnia * 100f;
        depthOfField.focalLength.value = playerStats.insomnia * 100f;
    }
}
