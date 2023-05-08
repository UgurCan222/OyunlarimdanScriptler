using UnityEngine;

public class Sagliklar : MonoBehaviour
{
    private Animator _anim;
    public float Can;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void ZararAl(float zararMiktari)
    {
        Can -= zararMiktari;
        if (Can <= 0)
        {
            _anim.SetTrigger("oldu");
            ObjeyiYokEt();
        }
    }

    private void ObjeyiYokEt()
    {
        Destroy(gameObject);
    }
}
