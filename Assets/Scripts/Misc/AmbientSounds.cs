using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSounds : MonoBehaviour
{
    float sound_timer = 0.0f;

    AudioSource audio_source;

    [SerializeField] float min_time_for_sound;
    [SerializeField] float max_time_for_sound;

    [SerializeField] AudioClip[] ambient_sounds;
    

    void Start()
    {
        audio_source = GetComponent<AudioSource>();

        sound_timer = Random.Range(min_time_for_sound, max_time_for_sound);
    }

    void Update()
    {
        sound_timer -= Time.deltaTime;
        print(sound_timer);

        if (sound_timer < 0.0f)
        {
            playRandomAmbientSound();
            sound_timer = Random.Range(min_time_for_sound, max_time_for_sound);
        }
    }

    void playRandomAmbientSound()
    {
        AudioClip chosen_sound = ambient_sounds[Random.Range(0, ambient_sounds.Length)];

        audio_source.PlayOneShot(chosen_sound);
    }
}
