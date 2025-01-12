using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectDucky : MonoBehaviour
{
    Animator animator;
    Transform parentDuck;
    public UI ui;
    private bool collected = false;
    public DuckCollection duckCollection;

    public void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        parentDuck = transform.parent.transform;

    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player") && !collected)
        {

            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Animator>().enabled = true;

            collected = true;
            Debug.Log("collided");

            if (animator != null)
            {
                Debug.Log("playing anim");

                parentDuck.LookAt(collision.transform);

                animator.Play("Duck");
                float animationDuration = GetAnimationClipLength("Duck");

                Debug.Log(animationDuration);
                StartCoroutine(HandleDuckCollection(animationDuration));

               
            }
        }

    }

    private IEnumerator HandleDuckCollection(float delay)
    {
        yield return new WaitForSeconds(delay);

        ui.AddDuck();
        duckCollection.AddDuck();
        Destroy(gameObject);
    }

    private float GetAnimationClipLength(string clipName)
    {
        // Find the animation clip in the Animator Controller
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            if (clip.name == clipName)
            {
                return clip.length;
            }
        }
        Debug.LogError("Animation clip not found: " + clipName);
        return 0f;
    }
}
