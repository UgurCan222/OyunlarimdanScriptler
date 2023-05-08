using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class OyuncuAyarlari
{
    private const string ANA_SES_ANAHTARI = "ana_ses";
    private const string ZORLUK_ANAHTARI = "zorluk";
    private const string SEVIYE_ANAHTARI = "seviye_acik_";

    public static void AnaSesiAyarla(float ses)
    {
        if (ses < 0f || ses > 1f)
        {
            Debug.LogError("[0,1] aralığı dışında bir değer giremezsiniz.");
            return;
        }
        
        PlayerPrefs.SetFloat(ANA_SES_ANAHTARI, ses);
    }

    public static float AnaSesiAl()
    {
        return PlayerPrefs.GetFloat(ANA_SES_ANAHTARI);
    }

    public static void SeviyeninKilidi(int seviye)
    {
        if (seviye >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogError("Oyunda olmayan bir sahne açılamaz.");
            return;
        }
        
        PlayerPrefs.SetInt(SEVIYE_ANAHTARI + seviye.ToString(), 1);
    }

    public static bool SeviyeAcikMi(int seviye)
    {
        if (seviye >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogError("Oyunda olmayan bir seviyenin kilidini sorgulayamazsın.");
            return false;
        }
        
        return PlayerPrefs.GetInt(SEVIYE_ANAHTARI + seviye.ToString()) == 1;
    }

    public static void zorluguAyarla(float zorluk)
    {
        if (zorluk < 1f || zorluk > 5f)
        {
            Debug.LogError("Zorluk seviyesi 1-5 arasında bir tamsayı olmalıdır.");
            return;
        }

        PlayerPrefs.SetFloat(ZORLUK_ANAHTARI, zorluk);
    }

    public static float zorluguAl()
    {
        return PlayerPrefs.GetFloat(ZORLUK_ANAHTARI);
    }
}
