using UnityEngine;
using System.Collections.Generic;

public class GhostController : MonoBehaviour
{
    private CharacterController _controller;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();

        if (_animator == null)
        {
            Debug.LogError("Animator component not found on ghost prefab.");
        }
    }

    public void ApplyAnimationParameters(Dictionary<string, float> animationParameters)
    {
        if (_animator == null) return;

        foreach (var param in animationParameters)
        {
            if (param.Key == "Grounded" || param.Key == "Jump" || param.Key == "FreeFall")
            {
                _animator.SetBool(param.Key, param.Value > 0.5f);
            }
            else
            {
                _animator.SetFloat(param.Key, param.Value);
            }
        }
    }

    private void OnFootstep(AnimationEvent animationEvent)
    {

    }

    private void OnLand(AnimationEvent animationEvent)
    {
        
    }
}