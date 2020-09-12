using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpriteAnimator : MonoBehaviour
{
    public Animation firstAnimation;
    public static SpriteAnimator i;

    private void Awake()
    {
        i = this;

    }

    public Animation CreateAnimation(Sprite[] sprites, float durationPerFrame, bool looping, float? duration, Action onFinished)
    {
        return new Animation(sprites, durationPerFrame, looping, duration, onFinished);
    }
    public void PlayAnimation(Animation animation, SpriteRenderer sr, Sprite originalSprite)
    {
        if (animation.stopPlaying == false)
        {
            animation.animationTimer += Time.deltaTime;
            animation.durationTimer += Time.deltaTime;
            if (animation.animationTimer >= animation.durationPerFrame)
            {
                animation.animationTimer = 0;
                animation.currentFrame++;
                if (animation.currentFrame >= animation.sprites.Length)
                {
                    animation.currentFrame = 0;
                }
                sr.sprite = animation.sprites[animation.currentFrame];
            }
            if (animation.looping == false && animation.durationTimer >= animation.duration)
            {
                sr.sprite = originalSprite;
                animation.onFinished?.Invoke();
                animation.onFinished = null;
                return;
            }
        }

    }

    public void StopAnimation(Animation animation)
    {
        animation.stopPlaying = true;
    }
    public void ResumeAnimation(Animation animation)
    {
        animation.stopPlaying = false;
    }
}
public class Animation
{
    public Sprite[] sprites;
    public float durationPerFrame;
    public float animationTimer = 0;
    public float durationTimer = 0;
    public int currentFrame = 0;
    public bool looping;
    public float? duration; //only valid if looping equals false
    public bool stopPlaying = false;
    public Action onFinished;
    public Animation(Sprite[] sprites, float durationPerFrame, bool looping, float? duration, Action onFinished)
    {
        this.sprites = sprites;
        this.durationPerFrame = durationPerFrame;
        this.looping = looping;
        this.onFinished = onFinished;
        if (!looping)
        {
            this.duration = duration;
        }
        else this.duration = null;


    }
}


