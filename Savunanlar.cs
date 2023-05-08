using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savunanlar : MonoBehaviour
{
	private GameObject mevcutHedef;
	public bool Dur;
	private float speed;
	private Animator objeninAnimatoru;
	public int maliyet;
	private SpriteRenderer spriteRenderer;
	// Start is called before the first frame update
	void Start()
	{
	    objeninAnimatoru = GetComponent<Animator>();
	    spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
	    spriteRenderer.sortingOrder = 	Mathf.RoundToInt(transform.position.y * -100f);

	    if (mevcutHedef == null) {
	        objeninAnimatoru.SetBool("SaldiriVarMi", false);
	        if (Dur) {
 	           transform.Translate(Vector3.right * Time.deltaTime * speed);
	        } else {
	            transform.Translate(Vector3.left * Time.deltaTime * speed);
	        }
	    }
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
	}

	public void SuAnkiSpeedAyarla(float hiz)
	{
	    speed = hiz;
	}

	public void ZararVer(float zararMiktari)
	{
	    if (mevcutHedef) {
	        Sagliklar sagliklar = mevcutHedef.GetComponent<Sagliklar>();
	        if (sagliklar) {
	            sagliklar.ZararAl(zararMiktari);
	        }
	    }
	}

	public void HedefiBelirle(GameObject hedefimiz)
	{
	    mevcutHedef = hedefimiz;
	}

