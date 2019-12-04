using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletAnimation : MonoBehaviour
{
    public Animator BulletAnimation;
    public string animationMove;
    // Start is called before the first frame update
    private void Awake()
    {
        BulletAnimation.Play(animationMove , 0, 0.25f);
        Destroy(gameObject, 1.0f);
    }
}
