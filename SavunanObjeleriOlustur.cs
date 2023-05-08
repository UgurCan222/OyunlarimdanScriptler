using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavunanObjeleriOlustur : MonoBehaviour
{
    public Camera bizimKameramiz;
    private ParayiTopla toplamPara;

    private GameObject savunanObjeParent;

    private void Awake()
    {
        toplamPara = FindObjectOfType<ParayiTopla>();
        savunanObjeParent = GameObject.Find("Savunanlar") ?? new GameObject("Savunanlar");
    }

    private void OnMouseDown()
    {
        Vector2 gercekDunyaPozisyonu = farePozisyonunuGercekDunyayaAktar();
        Vector2 gercekDunyaPozisyonunuYukariYuvarlama = pozisyonuYuvarla(gercekDunyaPozisyonu);
        GameObject olusacakSavunanObje = PanelElemanKontrol.seciliEleman;

        int savunanObjeninMaliyeti = olusacakSavunanObje.GetComponent<Savunanlar>().maliyet;

        if (toplamPara.ParayiKullan(savunanObjeninMaliyeti) == ParayiTopla.ObjeOlusturmaDurumu.BASARILI)
        {
            ObjeyiOlustur(olusacakSavunanObje, gercekDunyaPozisyonunuYukariYuvarlama);
        }
        else
        {
            Debug.Log("Bakiyeniz yetersiz.");
        }
    }

    private void ObjeyiOlustur(GameObject olusacakSavunanObjemiz, Vector2 gercekDunyaPozisyonunuYukariYuvarlamamiz)
    {
        Instantiate(PanelElemanKontrol.seciliEleman, gercekDunyaPozisyonunuYukariYuvarlamamiz, Quaternion.identity, savunanObjeParent.transform);
    }

    private Vector2 pozisyonuYuvarla(Vector2 yuvarlanacakPozisyon)
    {
        float rastgeleSayi = Random.Range(-0.25f, 0.25f);
        float yuvarlaX = Mathf.Ceil(yuvarlanacakPozisyon.x);
        float yuvarlaY = Mathf.Ceil(yuvarlanacakPozisyon.y);
        yuvarlaX += rastgeleSayi;
        yuvarlaY += rastgeleSayi;
        return new Vector2(yuvarlaX, yuvarlaY);
    }

    private Vector2 farePozisyonunuGercekDunyayaAktar()
    {
        Vector3 mousePozisyonu = bizimKameramiz.ScreenToWorldPoint(Input.mousePosition + bizimKameramiz.transform.forward * 15f);
        return new Vector2(Mathf.Ceil(mousePozisyonu.x), Mathf.Ceil(mousePozisyonu.y));
    }
}
