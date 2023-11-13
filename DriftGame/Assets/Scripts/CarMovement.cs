using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private Button accelerateButton;
    [SerializeField] private Button stopbt;
    [SerializeField] private GameObject wasdimg;

    // Параметры движения машинки
    [SerializeField] private float moveSpeed = 300f;
    [SerializeField] private float rotationSpeed = 200f;
    [SerializeField] private  float maxSpeed = 30f;
    [SerializeField] private float acceleration = 30f;
    [SerializeField] private float braking = 1f;
    [SerializeField] private float turnAngle = 28f;

    // Звук мотора
    [SerializeField] private AudioClip engineSound;
    [SerializeField] private float maxVolume = 0.09f;
    [SerializeField] private float minPitch = 0.8f;
    [SerializeField] private float maxPitch = 1.2f;

    // Колеса машинки
    [SerializeField] private GameObject frontLeftWheel;
    [SerializeField] private GameObject frontRightWheel;
    [SerializeField] private GameObject rearLeftWheel;
    [SerializeField] private GameObject rearRightWheel;

    private Rigidbody rb;
    [SerializeField] private float currentSpeed = 0f;
    private AudioSource engineAudioSource;
    private bool isMoving = false;

    private int platform;

    //дрифт
    [SerializeField] private AudioClip driftSound;
    private AudioSource driftAudioSource;

    public bool isRacePressed = false;
    public bool isbrakePressed = false;

    public float moveInput;
    public float turnInput;


    private int score;
    [SerializeField] private Text scorecount;

    [SerializeField] private GameObject[] carPrefabs;



    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            // Ограничение перемещения вверх и вниз
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            // Снятие ограничений при покидании границы
            rb.constraints = RigidbodyConstraints.None;
        }
    }
    private void Update()
    {
     if(YandexGame.savesData.record < score)
        {
            YandexGame.savesData.record = score;
            YandexGame.SaveProgress();
        }
            
        Debug.Log(PlayerPrefs.GetInt("record"));
    }
    private void Start()
    {

        if (Application.isMobilePlatform == true)
        {
            platform = 1;
            Debug.Log("MOBILE");
        }
        else
        {
            platform = 0;
            Debug.Log("PC");
        }
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0f, -0.5f, 0f); // Смещение центра масс для более реалистичной физики

        // Создаем и настраиваем источник звука мотора
        engineAudioSource = gameObject.AddComponent<AudioSource>();
        engineAudioSource.clip = engineSound;
        engineAudioSource.loop = true;
        engineAudioSource.playOnAwake = false;
        engineAudioSource.volume = 0f;
        engineAudioSource.pitch = minPitch;
        engineAudioSource.Play();


        driftAudioSource = gameObject.AddComponent<AudioSource>();
        driftAudioSource.clip = driftSound;
        driftAudioSource.loop = true;
        driftAudioSource.playOnAwake = false;
        driftAudioSource.volume = 0f;
        driftAudioSource.pitch = 1f; // Настройте подходящий питч для звука дрифта колес
        driftAudioSource.Play();


            if(YandexGame.savesData.carChoise == 0)
            {
                carPrefabs[0].SetActive(true);
            }
            else if (YandexGame.savesData.carChoise == 1)
            {
                carPrefabs[1].SetActive(true);
            }
            else if (YandexGame.savesData.carChoise == 2)
            {
                carPrefabs[2].SetActive(true);
            }
            else if (YandexGame.savesData.carChoise == 3)
            {
                carPrefabs[3].SetActive(true);
            }
            else if (YandexGame.savesData.carChoise == 4)
            {
                carPrefabs[4].SetActive(true);
            }
    }

    private void FixedUpdate()
    {
        if(platform == 1)
        {
            float turnInput = joystick.Horizontal;
        }
        else 
        {
           float turnInput = Input.GetAxis("Horizontal");
        }
        if (isRacePressed)
        {
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);

            // Включаем звук мотора
            engineAudioSource.volume = Mathf.Lerp(engineAudioSource.volume, maxVolume, Time.deltaTime * acceleration);
            engineAudioSource.pitch = Mathf.Lerp(engineAudioSource.pitch, maxPitch, Time.deltaTime * acceleration);
            isMoving = true;
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0f, braking * Time.deltaTime);
            // При отсутствии движения постепенно выключаем звук мотора
            if (isMoving)
            {
                engineAudioSource.volume = Mathf.Lerp(engineAudioSource.volume, 0f, Time.deltaTime * braking);
                engineAudioSource.pitch = Mathf.Lerp(engineAudioSource.pitch, minPitch, Time.deltaTime * braking);
            }
        }

        if (isbrakePressed)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, -maxSpeed / 2f, braking * Time.deltaTime);

            // Уменьшаем звук мотора при торможении
            engineAudioSource.volume = Mathf.Lerp(engineAudioSource.volume, 0f, Time.deltaTime * braking);
            engineAudioSource.pitch = Mathf.Lerp(engineAudioSource.pitch, minPitch, Time.deltaTime * braking);
            isMoving = true;
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0f, braking * Time.deltaTime);
            // При отсутствии движения постепенно выключаем звук мотора
            if (isMoving)
            {
                engineAudioSource.volume = Mathf.Lerp(engineAudioSource.volume, 0f, Time.deltaTime * braking);
                engineAudioSource.pitch = Mathf.Lerp(engineAudioSource.pitch, minPitch, Time.deltaTime * braking);
            }
        }

        if (platform == 0)
        {
            wasdimg.SetActive(true);
            moveInput = Input.GetAxis("Vertical");
            turnInput = Input.GetAxis("Horizontal");     
            // Применяем ускорение или торможение
            if (moveInput > 0)
            {
                currentSpeed += acceleration * Time.deltaTime;
                currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);

                // Включаем звук мотора
                engineAudioSource.volume = Mathf.Lerp(engineAudioSource.volume, maxVolume, Time.deltaTime * acceleration);
                engineAudioSource.pitch = Mathf.Lerp(engineAudioSource.pitch, maxPitch, Time.deltaTime * acceleration);
                isMoving = true;
            }
            else if (moveInput < 0)
            {
                currentSpeed = Mathf.Lerp(currentSpeed, -maxSpeed / 2f, braking * Time.deltaTime);

                // Уменьшаем звук мотора при торможении
                engineAudioSource.volume = Mathf.Lerp(engineAudioSource.volume, 0f, Time.deltaTime * braking);
                engineAudioSource.pitch = Mathf.Lerp(engineAudioSource.pitch, minPitch, Time.deltaTime * braking);
                isMoving = true;
            }
            else
            {
                currentSpeed = Mathf.Lerp(currentSpeed, 0f, braking * Time.deltaTime);

                // При отсутствии движения постепенно выключаем звук мотора
                if (isMoving)
                {
                    engineAudioSource.volume = Mathf.Lerp(engineAudioSource.volume, 0f, Time.deltaTime * braking);
                    engineAudioSource.pitch = Mathf.Lerp(engineAudioSource.pitch, minPitch, Time.deltaTime * braking);
                }
            }


            
            
            
            
            if (turnInput == 1 && currentSpeed >= 15f  || turnInput >= 0.8 && currentSpeed >= 15f)
            {
                AddScore(10);
                driftAudioSource.volume = Mathf.Lerp(driftAudioSource.volume, 0.3f, Time.deltaTime * acceleration);

              
            }
            else if (turnInput == -1 && currentSpeed >= 15f || turnInput <= -0.8 && currentSpeed >= 15f)
            {
                AddScore(10);
                driftAudioSource.volume = Mathf.Lerp(driftAudioSource.volume, 0.3f, Time.deltaTime * acceleration);
               
            }
            else
            {
                driftAudioSource.volume = Mathf.Lerp(driftAudioSource.volume, 0f, Time.deltaTime * braking);
            }
        }

        if (platform == 1)
        {
            joystick.gameObject.SetActive(true);
            accelerateButton.gameObject.SetActive(true);
            stopbt.gameObject.SetActive(true);
            turnInput = joystick.Horizontal;

        } 
        //УГОЛ
            transform.Rotate(Vector3.up, turnInput * rotationSpeed * Time.deltaTime);
            // Передвигаем машинку
            rb.MovePosition(transform.position + transform.forward * currentSpeed * Time.deltaTime);

            // Вращаем колеса
            float rotationAmount = currentSpeed / (2 * Mathf.PI * frontLeftWheel.GetComponent<MeshRenderer>().bounds.size.z / 2f) * 360f * Time.deltaTime;
            frontLeftWheel.transform.Rotate(Vector3.forward, rotationAmount);
            frontRightWheel.transform.Rotate(Vector3.forward, rotationAmount);
            rearLeftWheel.transform.Rotate(Vector3.forward, rotationAmount);
            rearRightWheel.transform.Rotate(Vector3.forward, rotationAmount);

    }


    void AddScore(int points)
    {
        score += points;
        scorecount.text = score.ToString();

            if (score > YandexGame.savesData.record)
            {
                YandexGame.savesData.record = score;
                YandexGame.SaveProgress();
            }
    }

    public void onPointerDownRaceButton()
    {
        isRacePressed = true;
    }
    public void onPointerUpRaceButton()
    {
        isRacePressed = false;
    }
  
    public void onPointerDownBackButton()
    {
        isbrakePressed = true;
    }
  public void onPointerUpBackButton()
    {
        isbrakePressed  = false;
    }

    /*
    // Settings
    public float MoveSpeed = 50;
    public float MaxSpeed = 15;
    public float Drag = 0.98f;
    public float SteerAngle = 20;
    public float Traction = 1;

    // Variables
    private Vector3 MoveForce;

    // Update is called once per frame
    void Update()
    {

        // Moving
        MoveForce += transform.forward * MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += MoveForce * Time.deltaTime;

        // Steering
        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * SteerAngle * Time.deltaTime);

        // Drag and max speed limit
        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed);

        // Traction
        Debug.DrawRay(transform.position, MoveForce.normalized * 3);
        Debug.DrawRay(transform.position, transform.forward * 3, Color.blue);
        MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, Traction * Time.deltaTime) * MoveForce.magnitude;
    */
}


