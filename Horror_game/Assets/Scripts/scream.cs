using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scream : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip ClipFx;
    public Animator animator;
    private bool hasScreamed = false;
    private void OnEnable()
    {
        if (!hasScreamed)
        {
            hasScreamed = true;
            myFx.PlayOneShot(ClipFx);
            StartCoroutine(WaitAndDestroy());
        }
    }

    private IEnumerator WaitAndDestroy()
    {
        float clipLength = ClipFx.length;
        if (animator != null)
        {
            AnimatorStateInfo animInfo = animator.GetCurrentAnimatorStateInfo(0);
            clipLength = Mathf.Max(clipLength, animInfo.length);
        }
        yield return new WaitForSeconds(clipLength);
        Destroy(gameObject);
    }
}
