using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAudio : MonoBehaviour
{
    float sound_timer = 0.0f;

    AudioSource audio_source;

    [SerializeField] float min_time_for_sound;
    [SerializeField] float max_time_for_sound;
    [SerializeField] float sound_effect_volume;

    [SerializeField] AudioClip[] sounds;

    [SerializeField] EntityAI entity_ai;

    void Start()
    {
        entity_ai = GetComponent<EntityAI>();

        audio_source = GetComponent<AudioSource>();
        sound_timer = Random.Range(min_time_for_sound, max_time_for_sound);
    }

    void Update()
    {
        if (!entity_ai.getJumpscaring() && !entity_ai.getDisabled())
        {
            sound_timer -= Time.deltaTime;

            if (sound_timer <= 0.0f)
            {
                playRandomSound();
                sound_timer = Random.Range(min_time_for_sound, max_time_for_sound);
            }
        }
    }

    void playRandomSound()
    {
        AudioClip chosen_sound = sounds[Random.Range(0, sounds.Length)];

        audio_source.PlayOneShot(chosen_sound, sound_effect_volume);
    }
}
