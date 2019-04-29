using System;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            return;
        }

        if (!s.isOST && s.source.isPlaying) {
            s.source.Stop();
            s.source.Play();
        } else if (!s.source.isPlaying) {
            s.source.Play();
        }

    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Stop();
    }

    public void StopAll()
    {
        foreach (Sound s in sounds)
        {
            if (s.source.isPlaying)
            {
                s.source.Stop();
            }
        }
    }

    public IEnumerator PlayFor(String name, float seconds)
    {
        Play(name);
        yield return new WaitForSeconds(seconds);
        Stop(name);
    }

    public void PlayerHitWood()
    {
        HitWood();
        HitPlayer();
    }

    public void HitWood()
    {
        Play("shock_wood");
        Play("break_wood");
    }

    public void PlayerHitMetal()
    {
        HitMetal();
        HitPlayer();
    }

    public void HitMetal()
    {
        Play("shock_metal");
    }

    public void PlayerHitGarbage()
    {
        HitGarbage();
        HitPlayer();
    }

    public void HitGarbage()
    {
        Play("shock_garbage");
    }

    public void HitPlayer()
    {
        Play("fight_man_2");
        Play("shock_body_fall");
    }

    public void StartRunning()
    {
        Play("running_step");
        Play("running_cloth");
    }

    public void StopRunning()
    {
        Stop("running_step");
        Stop("running_cloth");
    }

    public void FailRobbing()
    {
        Play("fight_man_2");
    }

    public void Dash()
    {
        Play("transition_sweep");
    }

    public void EarReward()
    {
        StartCoroutine(PlayFor("coin_2",1.5F));
    }

    public void StartJump()
    {
        StopRunning();
    }

    public void StopJump()
    {
        StartRunning();
    }

    public void StartIntro()
    {
        Play("Intro");
    }

    public void SuccessQTE()
    {
        Play("success_qte");
    }
}