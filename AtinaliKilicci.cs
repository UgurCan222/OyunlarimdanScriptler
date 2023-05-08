using UnityEngine;

public class AtinaliKilicci : MonoBehaviour
{
    private Animator AtinaliKilicciAnimator;
    private void Start()
    {
        AtinaliKilicciAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject AtinaliKiliccininEtkilesimeGirdigiObje = collision.gameObject;

        if (AtinaliKiliccininEtkilesimeGirdigiObje.GetComponent<Savunanlar>())
        {
            AtinaliKilicciAnimator.SetBool("SaldiriVarMi", true);
            GetComponent<Askerler>().HedefiBelirle(AtinaliKiliccininEtkilesimeGirdigiObje);
        }
    }
}
