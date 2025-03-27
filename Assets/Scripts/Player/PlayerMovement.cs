using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    bool is_grounded;
    bool waiting_for_stamina = false;

    float accelerating_timer = 0.0f;
    float internal_speed_multiplier = 1.0f; //speed multiplier affected by player input (sprinting or sneaking)
    float external_speed_multiplier = 1.0f; //speed multiplier affected by external factors (walking on slime)
    float air_speed_multiplier = 1.0f;
    float respawn_move_timer = 0.0f;
    float jump_timer = 0.0f;
    float max_speed;
    float stamina = 1.0f;

    Rigidbody rb;

    MoveAudioState move_audio_state;

    [SerializeField] float acceleration;
    [SerializeField] float jump_force;
    [SerializeField] float base_max_speed;

    [SerializeField] float start_external_speed_multiplier;
    [SerializeField] float sprint_speed_multiplier;
    [SerializeField] float sneak_speed_multiplier;

    [SerializeField] float jump_cooldown;

    [SerializeField] float ground_check_radius;
    [SerializeField] float ground_drag;
    [SerializeField] float air_drag;
    [SerializeField] float air_speed_multiplier_air_value;

    [SerializeField] float respawn_move_cooldown;

    [SerializeField] float stamina_drain_rate;
    [SerializeField] float stamina_regen_rate;

    [SerializeField] Transform ground_check_transform;
    [SerializeField] Transform camera_transform;

    [SerializeField] AudioClip jump_sound;
    [SerializeField] AudioClip walk_sound;
    [SerializeField] AudioClip run_sound;

    [SerializeField] AudioSource main_audio_source;
    [SerializeField] AudioSource panting_audio_source;

    [SerializeField] Slider stamina_bar;

    void Start()
    {
        max_speed = base_max_speed;
        rb = GetComponent<Rigidbody>();

        external_speed_multiplier = start_external_speed_multiplier;
    }

    void Update()
    {
        jumpAndAirCheck();
        updateMoveAudio();
        updateTimers();      
    }

    private void FixedUpdate()
    {
        movePlayer();
    }

    void jumpAndAirCheck()
    {
        //check if grounded before checking jump input
        is_grounded = Physics.CheckSphere(ground_check_transform.position, ground_check_radius, LayerMask.GetMask("Ground"));

        if (is_grounded)
        {
            rb.drag = ground_drag;
            air_speed_multiplier = 1.0f;
        }
        else
        {
            rb.drag = air_drag;
            air_speed_multiplier = air_speed_multiplier_air_value;
        }

        //jump
        if (Input.GetButtonDown("Jump") && is_grounded && jump_timer <= 0.0f)
        {
            jump();
        }
    }

    void movePlayer()
    {
        if (respawn_move_timer <= 0.0f)
        {
            //get movement inputs
            //axis
            float horizontal_input = Input.GetAxis("Horizontal");
            float vertical_input = Input.GetAxis("Vertical");

            //sprint/sneak
            if (Input.GetButton("Sprint") && is_grounded && stamina > 0.0f && !waiting_for_stamina)
            {
                internal_speed_multiplier = sprint_speed_multiplier;
            }
            else if (Input.GetButton("Sneak") && is_grounded)
            {
                internal_speed_multiplier = sneak_speed_multiplier;
            }
            else if (!Input.GetButton("Sprint") && !Input.GetButton("Sneak") && is_grounded && accelerating_timer <= 0.0f)
            {
                internal_speed_multiplier = 1.0f;
            }

            if (internal_speed_multiplier == sprint_speed_multiplier && (horizontal_input != 0.0f || vertical_input != 0.0f))
            {
                stamina -= stamina_drain_rate * Time.deltaTime;

                if (stamina <= 0.0f)
                {
                    internal_speed_multiplier = 1.0f;
                    stamina = 0.0f;

                    waiting_for_stamina = true;

                    panting_audio_source.Play();
                }

                stamina_bar.value = stamina;
            }
            else if (stamina < 1.0f)
            {
                stamina += stamina_regen_rate * Time.deltaTime;

                if (stamina >= 1.0f)
                {
                    stamina = 1.0f;

                    waiting_for_stamina = false;

                    panting_audio_source.Stop();
                }

                stamina_bar.value = stamina;
            }

            //set max speed
            max_speed = base_max_speed * internal_speed_multiplier * external_speed_multiplier;

            //calculate movement force based on input and speed multipliers

            Vector3 move_direction = transform.forward * vertical_input + transform.right * horizontal_input;
            Vector3 move_force = move_direction.normalized * acceleration * internal_speed_multiplier * external_speed_multiplier * air_speed_multiplier;

            rb.AddForce(move_force, ForceMode.Force);


            //check speed hasn't exceeded maximum
            Vector3 flat_velocity = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z);

            if (flat_velocity.magnitude > max_speed)
            {
                Vector3 limited_velocity = flat_velocity.normalized * max_speed;
                rb.velocity = new Vector3(limited_velocity.x, rb.velocity.y, limited_velocity.z);
            }
        }
    }

    void updateMoveAudio()
    {
        if (is_grounded && (Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") != 0.0f) && internal_speed_multiplier == 1.0f)
        {
            move_audio_state = MoveAudioState.WALKING;
        }
        else if (is_grounded && (Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") != 0.0f) && internal_speed_multiplier > 1.0f)
        {
            move_audio_state = MoveAudioState.SPRINTING;
        }
        else
        {
            move_audio_state = MoveAudioState.NO_AUDIO;
        }

        switch(move_audio_state)
        {
            case MoveAudioState.WALKING:
                {
                    main_audio_source.clip = walk_sound;
                    break;
                }

            case MoveAudioState.SPRINTING:
                {
                    main_audio_source.clip = run_sound;
                    break;
                }

            case MoveAudioState.NO_AUDIO:
                {
                    main_audio_source.clip = null;
                    return;
                }            
        }

        if (!main_audio_source.isPlaying)
        {
            main_audio_source.Play();
        }

        
    }

    void updateTimers()
    {
        if (accelerating_timer > 0.0f)
        {
            accelerating_timer -= Time.deltaTime;
        }

        if (respawn_move_timer > 0.0f)
        {
            respawn_move_timer -= Time.deltaTime;
        }

        if (jump_timer > 0.0f)
        {
            jump_timer -= Time.deltaTime;
        }
    }

    void jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z);
        rb.AddForce(Vector3.up * jump_force, ForceMode.Impulse);

        //play jump sound
        main_audio_source.PlayOneShot(jump_sound);

        //set jump timer
        jump_timer = jump_cooldown;
    }

    public void respawnMoveTimer()
    {
        respawn_move_timer = respawn_move_cooldown;
    }

    public void setExternalSpeedMultiplier(float new_external_speed_multiplier)
    {
        external_speed_multiplier = new_external_speed_multiplier;
    }

    enum MoveAudioState
    {
        NO_AUDIO = 1,
        WALKING = 2,
        SPRINTING = 3
    }
}
