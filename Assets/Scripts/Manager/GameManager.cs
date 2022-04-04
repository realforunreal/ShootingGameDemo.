using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = new GameManager();

    private void Awake()
    {
        instance = this;
        if (instance == null)
        {
            instance = new GameManager();
        }
        DontDestroyOnLoad(this.gameObject);
    }

        [Header("CameraViewMap")]
        public Vector2 camera_zero;
        public Vector2 camera_top;

    private void Start()
    {
        camera_zero = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        camera_top = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
    }

    public GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    [Header("Player Struct")]
    public GameObject player;
    public Pilot p_Pilot;
    public BulletSet p_BulletSet;
    public float p_Hp;
    float p_MaxHp;

    [Header("")]
    public ItemManager itemManager;
    //public BulletSet p_BulletSet;

    [Header("EnemySpawner")]
    public EnemySpawner spawner;

    public FadeEffect fade;
    
}
