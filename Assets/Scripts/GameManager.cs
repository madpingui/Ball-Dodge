using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { set; get; }

    public GameObject gameLobbyPanel, tapPanel, deathPanel, gameMenuPanel;
    private GameObject player;
    private PlayerMotor motor;
    public SlidingNumber camara;

    public bool isDead { set; get; }
    public static bool Once = false;   

    private float score;
    public Text scoreText, highText;

    private float audioDeath;

    private AudioSource aud;
    public AudioClip playAudio;
    public GameObject rewardDeath;
    public GameObject particulasOrbita;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        Once = false;
        Instance = this;
        motor = player.GetComponent<PlayerMotor>();

        scoreText.text = score.ToString("0");
        highText.text = "Hs: " + PlayerPrefs.GetInt("Hiscore").ToString();

        if (PlayerPrefs.GetInt("Replay") == 1)
        {
            Jugar();
        }
        PlayerPrefs.SetInt("Replay", 0);
    }

    public void Update()
    {
        if(isDead == true)
        {
            audioDeath += Time.deltaTime;
            aud.volume = Mathf.Lerp(1, 0.1f, audioDeath/2);
            aud.pitch = Mathf.Lerp(1, 0.6f, audioDeath);
        }

        if (isDead == false)
        {
            if (player.transform.position.z > 0)
            {
                score = player.transform.position.z;
                scoreText.text = score.ToString("0");
            }
        }
    }

    public void Jugar()
    {
        tapPanel.SetActive(true);
        gameLobbyPanel.SetActive(false);
    }

    public void empezar()
    {
        particulasOrbita.SetActive(false);
        gameMenuPanel.SetActive(true);
        tapPanel.SetActive(false);
        aud.clip = playAudio;
        aud.volume = 1;
        aud.Play();
        Once = true;
        motor.StartRunning();
        FindObjectOfType<CamaraMotor>().IsMoving = true;
    }

    public void Lobby()
    {
        SceneManager.LoadScene("Juego");
    }

    public void Resetear()
    {
        PlayerPrefs.SetInt("Replay", 1);
        SceneManager.LoadScene("Juego");
    }

    private void SlidingNumbers()
    {
        camara.AddToNumber(score);
        camara.AddToNumber2(PlayerPrefs.GetInt("Hiscore"));
    }

    public void onDeath()
    {
        isDead = true;
        deathPanel.SetActive(true);
        gameMenuPanel.SetActive(false);      

        if (score > PlayerPrefs.GetInt("Hiscore"))
        {
            float s = score;

            if (s % 1 == 0)
            {
                s += 1;
            }
            PlayerPrefs.SetInt("Hiscore", (int)s);           
        }

        SlidingNumbers();

        if(score >= 500)
        {
            if(PlayerPrefs.GetInt("Bloqueo1") == 0)
            {
                rewardDeath.SetActive(true);
            }

            PlayerPrefs.SetInt("Bloqueo1", 1);
            if (score >= 1000)
            {
                if (PlayerPrefs.GetInt("Bloqueo2") == 0)
                {
                    rewardDeath.SetActive(true);
                }

                PlayerPrefs.SetInt("Bloqueo2", 1);
                if (score >= 1500)
                {
                    if (PlayerPrefs.GetInt("Bloqueo3") == 0)
                    {
                        rewardDeath.SetActive(true);
                    }

                    PlayerPrefs.SetInt("Bloqueo3", 1);
                    if (score >= 2000)
                    {
                        if (PlayerPrefs.GetInt("Bloqueo4") == 0)
                        {
                            rewardDeath.SetActive(true);
                        }

                        PlayerPrefs.SetInt("Bloqueo4", 1);
                    }
                }
            }
        }
    }

    public void borrarPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
