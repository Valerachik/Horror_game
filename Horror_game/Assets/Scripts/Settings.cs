using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Settings : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;

    Resolution[] resolutions;

    void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        LoadSettings(currentResolutionIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingPreference", qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference", Screen.fullScreen ? 1 : 0);
    }

    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("QualitySettingPreference"))
        {
            qualityDropdown.value = PlayerPrefs.GetInt("QualitySettingPreference");
            QualitySettings.SetQualityLevel(qualityDropdown.value);
        }
        else
        {
            qualityDropdown.value = 3;
            QualitySettings.SetQualityLevel(3);
        }

        if (PlayerPrefs.HasKey("ResolutionPreference"))
        {
            int resolutionIndex = PlayerPrefs.GetInt("ResolutionPreference");
            resolutionDropdown.value = resolutionIndex;
            SetResolution(resolutionIndex);
        }
        else
        {
            resolutionDropdown.value = currentResolutionIndex;
            SetResolution(currentResolutionIndex);
        }

        if (PlayerPrefs.HasKey("FullscreenPreference"))
        {
            bool isFullscreen = PlayerPrefs.GetInt("FullscreenPreference") == 1;
            Screen.fullScreen = isFullscreen;
        }
        else
        {
            Screen.fullScreen = true;
        }
    }

}

