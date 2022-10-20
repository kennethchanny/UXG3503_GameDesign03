using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class postprocess : MonoBehaviour
{  //reference the PP
    private Volume volume;
    private VolumeProfile volumeProfile;
    //Vignette reference
    private Vignette vignetteref;
    private Bloom bloomref;
    private ShadowsMidtonesHighlights shadowsmidtoneshighlightsref;
    private ChromaticAberration chromaticabberationref;
    private FilmGrain filmgrainref;
    private ColorAdjustments coloradjustmentsref;
    private CameraShakeManager camerashakeref;
    public CameraFollowTarget cameraplayerdistancecheckerref;


    public float dangerchromaticabberationintensitymultiplier = 0.05f;
    public float dangerfilmgrainintensitymultiplier = 0.05f;
    public float dangervignetteintensitymultiplier = 0.05f;
    public float dangerbloomintensitymultiplier = 0.05f;
    public float dangercolorintensitymultiplier = 0.05f;


    public bool isinGame = false;
    // Start is called before the first frame update
    void Start()
    {
        
        volume = gameObject.GetComponent<Volume>();
        volumeProfile = GetComponent<UnityEngine.Rendering.Volume>()?.profile;
        if (!volumeProfile) throw new System.NullReferenceException(nameof(UnityEngine.Rendering.VolumeProfile));

        //Vignette reference
        UnityEngine.Rendering.Universal.Vignette vignette;
        if (!volumeProfile.TryGet(out vignette)) throw new System.NullReferenceException(nameof(vignette));
        //Bloom ref
        UnityEngine.Rendering.Universal.Bloom bloom;
        if (!volumeProfile.TryGet(out bloom)) throw new System.NullReferenceException(nameof(bloom));
        //shadowsmidtoneshighlights ref
        UnityEngine.Rendering.Universal.ShadowsMidtonesHighlights shadowsmidtoneshighlights;
        if (!volumeProfile.TryGet(out shadowsmidtoneshighlights)) throw new System.NullReferenceException(nameof(shadowsmidtoneshighlights));

        UnityEngine.Rendering.Universal.ChromaticAberration chromaticabberation;
        if (!volumeProfile.TryGet(out chromaticabberation)) throw new System.NullReferenceException(nameof(chromaticabberation));


        UnityEngine.Rendering.Universal.ColorAdjustments coloradjustments;
        if (!volumeProfile.TryGet(out coloradjustments)) throw new System.NullReferenceException(nameof(coloradjustments));

        UnityEngine.Rendering.Universal.FilmGrain filmgrain;
        if (!volumeProfile.TryGet(out filmgrain)) throw new System.NullReferenceException(nameof(filmgrain));

        //REFERENCES===============================================
        //vignette reference
        vignetteref = vignette;
        //bloom ref
        bloomref = bloom;
        //shadowsmidtoneshighlights
        shadowsmidtoneshighlightsref = shadowsmidtoneshighlights;
        //Chromatic
        chromaticabberationref = chromaticabberation;
        //color adjustments
        coloradjustmentsref = coloradjustments;

        filmgrainref = filmgrain;


    }

    private void OnDestroy()
    {

    }

 
    void UpdateSeparationPostProcess()
    {
            
        
        float chromaticvalue = cameraplayerdistancecheckerref.playerseparation;
        chromaticabberationref.intensity.Override(chromaticvalue * dangerchromaticabberationintensitymultiplier);

        float bloomvalue = cameraplayerdistancecheckerref.playerseparation;
        bloomref.intensity.Override(bloomvalue * dangerbloomintensitymultiplier);

        float vignettevalue = cameraplayerdistancecheckerref.playerseparation;
        vignetteref.intensity.Override(Mathf.Clamp(vignettevalue * dangerbloomintensitymultiplier,0.3f,7));

        float coloradjustmentsvalue = cameraplayerdistancecheckerref.playerseparation;
        coloradjustmentsref.saturation.Override(-coloradjustmentsvalue * dangercolorintensitymultiplier);
        coloradjustmentsref.contrast.Override(-coloradjustmentsvalue * dangercolorintensitymultiplier);

        float filmgrainvalue = cameraplayerdistancecheckerref.playerseparation;
        filmgrainref.intensity.Override(filmgrainvalue * dangerfilmgrainintensitymultiplier);
        filmgrainref.response.Override(filmgrainvalue * dangerfilmgrainintensitymultiplier);
    }


    public void OffPP()
    {
        isinGame = false;
        vignetteref.intensity.Override(0.2f);
        filmgrainref.intensity.Override(0.2f);
       
    }

    public void OnPP()
    {
        isinGame = true;
    }


    // Update is called once per frame
    void Update()
    {
        if(isinGame)
        UpdateSeparationPostProcess();
    }
}
