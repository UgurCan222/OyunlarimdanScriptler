using UnityEngine;

public class Askerler : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float kacSaniyedeBirDogacak;
    [SerializeField] private bool Dur;
    private Animator animator;
    private GameObject currentTarget;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (currentTarget)
        {
            animator.SetBool("SaldiriVarMi", true);
            transform.position = Vector2.MoveTowards(transform.position, currentTarget.transform.position, speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("SaldiriVarMi", false);
            if (Dur)
            {
                transform.Translate(0 * Time.deltaTime * speed , 0,0);
            }
            else
            {
                transform.Translate(-1 * Time.deltaTime * speed / 40 , 0,0);
            }
        }
    }


    public void SuAnkiSpeedAyarla(float hiz)
    {
        speed = hiz;
    }

    public void ZararVer(float zararMiktari)
    {
        if (currentTarget)
        {
            Sagliklar sagliklar = currentTarget.GetComponent<Sagliklar>();
            if (sagliklar)
            {
                sagliklar.ZararAl(zararMiktari);
            }
        }
    }

    public void HedefiBelirle(GameObject hedefimiz)
    {
        currentTarget = hedefimiz;
    }
}
