using UnityEngine;
public class LocalizationChanger : MonoBehaviour
{
    public void SetLocale(string locale)
    {
        Localizer.SelectedLanguage = locale;
    }
}

