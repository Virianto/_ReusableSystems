using System.Collections.Generic;
using Code.Utils;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Daytime Light Manager
/// This class is responsible for maintaining control over the time of day represented in the scene
/// and communicating it to other classes via events.
/// </summary>
public class M_DaytimeLight : CircularIndicesNavigator<SO_SingleDaytimeConfig, M_DaytimeLight>
{
    #region ATTRIBUTES    

    #region Events
    
    public delegate void DaytimeChanged();
    public DaytimeChanged OnDaytimeChanged;   

    #endregion

    [Header("External references")]

    [SerializeField] Light mainDirectionalLight;

    [Space(5)]

    //[SerializeField] List<SO_SingleDaytimeConfig> allConfigDataList = new();

    [Header("Editable values")]

    [SerializeField] Key nextKey;
    [SerializeField] Key previousKey;

    [SerializeField] [Range(0.1f, 15)] float transitionTime = 3;

    [SerializeField] Ease transitionEase = Ease.OutCubic;
    
    Material _myOwnMat;

    Daytime _currentDaytime = Daytime.Midday;

    public Daytime CurrentDaytime
    {
        get => _currentDaytime;
        set
        {
            if(_currentDaytime != value)
            {
                _currentDaytime = value;
            }            
        }
    }

    #endregion

    #region METHODS

    /// <summary>
    /// We reference the skybox material that the scene is currently using and avoid
    /// overwriting it during execution by creating a new instance
    /// </summary>
    void Awake()
    {
        _myOwnMat = new Material(RenderSettings.skybox);
        RenderSettings.skybox = _myOwnMat;
    }

    void Update()
    {
        if(Keyboard.current.allKeys[(int)nextKey - 1].wasPressedThisFrame)
        {
            CurrentDaytimeSwitched(true);
        }
        if (Keyboard.current.allKeys[(int)previousKey - 1].wasPressedThisFrame)
        {
            CurrentDaytimeSwitched(false);
        }
    }

    void CurrentDaytimeSwitched(bool isNext)
    {
        if(isNext)
        {
            SwitchToNextIndex();
        }
        else
        {
            SwitchToPreviewIndex();
        }
        
        SetNewLightingData(_allItemsList[CurrentIndex].configData);
        CurrentDaytime = _allItemsList[CurrentIndex].configData.daytime;
        
        OnDaytimeChanged?.Invoke();
    }

    /// <summary>
    /// This method shall be implemented using Unity awaitables or any other plugin if you
    /// want to avoid DOTween dependency
    /// </summary>
    /// <param name="lightingData"></param>
    void SetNewLightingData(D_SingleDaytime lightingData)
    {
        // Modifying lighting configuration

        DOTween.To(() => mainDirectionalLight.colorTemperature, x => mainDirectionalLight.colorTemperature = x, lightingData.mainLightTemperature, transitionTime).SetEase(transitionEase);

        DOTween.To(() => mainDirectionalLight.transform.eulerAngles, x => mainDirectionalLight.transform.eulerAngles = x, lightingData.lightRotation, transitionTime).SetEase(transitionEase);

        DOTween.To(() => mainDirectionalLight.intensity, x => mainDirectionalLight.intensity = x, lightingData.lightIntensity, transitionTime).SetEase(transitionEase);

        // Modifying material configuration

        DOTween.To(() => _myOwnMat.GetFloat("_SunSize"), x => _myOwnMat.SetFloat("_SunSize", x), lightingData.sunOrMoonSize, transitionTime).SetEase(transitionEase);

        DOTween.To(() => _myOwnMat.GetFloat("_SunSizeConvergence"), x => _myOwnMat.SetFloat("_SunSizeConvergence", x), lightingData.sunOrMoonSizeConvergence, transitionTime).SetEase(transitionEase);

        DOTween.To(() => _myOwnMat.GetFloat("_AtmosphereThickness"), x => _myOwnMat.SetFloat("_AtmosphereThickness", x), lightingData.atmosphereThickness, transitionTime).SetEase(transitionEase);

        DOTween.To(() => _myOwnMat.GetColor("_SkyTint"), x => _myOwnMat.SetColor("_SkyTint", x), lightingData.skyTint, transitionTime).SetEase(transitionEase);

        DOTween.To(() => _myOwnMat.GetColor("_GroundColor"), x => _myOwnMat.SetColor("_GroundColor", x), lightingData.groundColor, transitionTime).SetEase(transitionEase);

        DOTween.To(() => _myOwnMat.GetFloat("_Exposure"), x => _myOwnMat.SetFloat("_Exposure", x), lightingData.exposure, transitionTime).SetEase(transitionEase);
    }

    #endregion
}
