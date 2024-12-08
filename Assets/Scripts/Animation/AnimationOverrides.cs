using System.Collections.Generic;
using UnityEngine;

public class AnimationOverrides : MonoBehaviour
{
    [SerializeField] private GameObject character;
    [SerializeField] private SO_AnimationType[] soAnimationTypeArray;

    private Dictionary<AnimationClip, SO_AnimationType> animationTypeDictionaryByAnimation;
    private Dictionary<string, SO_AnimationType> animationTypeDictionaryCompositeAttributeKey;

    private void Start()
    {
        animationTypeDictionaryByAnimation = new Dictionary<AnimationClip, SO_AnimationType>();

        foreach(SO_AnimationType item in soAnimationTypeArray)
        {
            animationTypeDictionaryByAnimation.Add(item.animationClip, item);
        }

        animationTypeDictionaryCompositeAttributeKey = new Dictionary<string, SO_AnimationType>();

        foreach(SO_AnimationType item in soAnimationTypeArray)
        {
            string key = item.characterPart.ToString() + item.partVariantColor.ToString() + item.partVariantType.ToString() + item.animationName.ToString();
            animationTypeDictionaryCompositeAttributeKey.Add(key, item);
        }
    }

    public void ApplyCharacterCustomisationParameters(List<CharacterAttribute> characterAttributesList)
    {
        foreach(CharacterAttribute characterAttribute in characterAttributesList)
        {
            Animator currentAnimator = null;
            List<KeyValuePair<AnimationClip, AnimationClip>> animsKeyValuePairList = new List<KeyValuePair<AnimationClip, AnimationClip>>();

            string animatorSoAssetName = characterAttribute.characterPartAnimator.ToString();

            Animator[] animatorsArray = character.GetComponentsInChildren<Animator>();

            foreach(Animator animator in animatorsArray)
            {
                if(animator.name == animatorSoAssetName)
                {
                    currentAnimator = animator;
                    break;
                }
            }

            //AnimationOverrideController kısmı
            AnimatorOverrideController aoc = new AnimatorOverrideController(currentAnimator.runtimeAnimatorController);
            List<AnimationClip> animationsList = new List<AnimationClip>(aoc.animationClips);
            

            foreach(AnimationClip animationClip in animationsList)
            {
                SO_AnimationType so_AnimationType;
                bool foundAnimation = animationTypeDictionaryByAnimation.TryGetValue(animationClip, out so_AnimationType);


                if(foundAnimation)
                {
                    string key = characterAttribute.characterPartAnimator.ToString() + characterAttribute.partVariantColor.ToString()
                       + characterAttribute.partVariantType.ToString() + so_AnimationType.animationName.ToString();

                    SO_AnimationType swapSo_AnimationType;
                    bool foundSwapAnimation = animationTypeDictionaryCompositeAttributeKey.TryGetValue(key, out swapSo_AnimationType);

                    if(foundSwapAnimation)
                    {
                        AnimationClip swapAnimationClip = swapSo_AnimationType.animationClip;

                        animsKeyValuePairList.Add(new KeyValuePair<AnimationClip,AnimationClip>(animationClip, swapAnimationClip));
                    }
                }
            }

            aoc.ApplyOverrides(animsKeyValuePairList);
            currentAnimator.runtimeAnimatorController = aoc;
        }
       
        
    }
}
