using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    float sound_timer = 0.0f;

    AudioSource audio_source;

    [SerializeField] float min_time_for_sound;
    [SerializeField] float max_time_for_sound;
    [SerializeField] float sound_effect_volume;

    [SerializeField] AudioClip[] music_to_choose_from;

    [SerializeField] AudioClip[] ambient_sounds;
    

    void Start()
    {
        audio_source = GetComponent<AudioSource>();

        audio_source.clip = music_to_choose_from[Random.Range(0, music_to_choose_from.Length)];

        sound_timer = Random.Range(min_time_for_sound, max_time_for_sound);
    }

    void Update()
    {
        sound_timer -= Time.deltaTime;

        if (sound_timer < 0.0f)
        {
            playRandomAmbientSound();
            sound_timer = Random.Range(min_time_for_sound, max_time_for_sound);
        }
    }

    void playRandomAmbientSound()
    {
        AudioClip chosen_sound = ambient_sounds[Random.Range(0, ambient_sounds.Length)];

        audio_source.PlayOneShot(chosen_sound, sound_effect_volume);
    }
}
