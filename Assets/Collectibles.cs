using System.Collections;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [SerializeField] Animator StrawberryAnimator;
    void Start()
    {

    }
    void Update()
    {

    }

    private void AnimatorHandle()
    {
        StrawberryAnimator.SetTrigger("Trigger Collected");
    }

    private IEnumerator PlayAnimationAndDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AnimatorHandle();
            StartCoroutine(PlayAnimationAndDestroy());  
        }
    }
}
