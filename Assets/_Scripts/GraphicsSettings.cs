using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class GraphicsSettings : MonoBehaviour
{
    private Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    void Start()
    {
        resolutions = Screen.resolutions;
        List<string> options = new List<string>();
        int currentResolutionOption = 0;

        resolutionDropdown.ClearOptions();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;

            options.Add(option);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionOption = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionOption;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetQuality(int optionIndex)
    {
        QualitySettings.SetQualityLevel(optionIndex);
    }
    
    public void SetResolution(int optionIndex)
    {
        Resolution res = resolutions[optionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void PlayInWindow(bool windowed)
    {
        Screen.fullScreen = !windowed;
    }

}
