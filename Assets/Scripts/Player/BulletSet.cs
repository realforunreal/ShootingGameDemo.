using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSet : MonoBehaviour
{
    public GameObject bullet;
    public Pilot pilot;
    public string pilotName;

    public enum Bullet_State { InitWay, Multiple}
    public Bullet_State bullet_state;

    public int bulletNumber;
    public float bulletPower;
    public float bulletTheta;
    public float bulletShotTime;
    public Vector2 velocity;
    public float xOffset;

    float[] vx, vy;

    private void Awake()
    {
    }
    private void Start()
    {
        GameManager.instance.p_BulletSet = this;
        pilot = GameManager.instance.p_Pilot;
        LoadPilot();
    }
    void LoadPilot()
    {
        PilotData data = SaveLoadManager.Load();
        Debug.Log(data.bulletNum);
        pilotName = data.name;
        Debug.Log(pilotName);
        bulletNumber = data.bulletNum;
        bulletPower = data.bulletPower;
        if (data.bulletType == "Initway")
        {
            bullet_state = BulletSet.Bullet_State.InitWay;
        }
        else if (data.bulletType == "Multiple")
        {
            bullet_state = BulletSet.Bullet_State.Multiple;
        }
        Debug.Log(data.name);
    }
    void InitNWayBullets(float vx0, float vy0, float theta, int n)
    {
        float rad_step = (float)Mathf.PI / 180.0f * theta;

        float rad;
        if (n % 2 == 0)
        {
            rad = (-n / 2 +0.5f) * rad_step;
        }
        else
        {
            rad = -n / 2 * rad_step;
        }

        vx = new float[n];
        vy = new float[n];

        for (int i = 0; i < n; i++, rad += rad_step)
        {
            float c = (float)Mathf.Cos(rad);
            float s = (float)Mathf.Sin(rad);
            vx[i] = vy0 * s;
            vy[i] = vy0 * c;
        }
    }

    void MultipleShots()
    {
        t += Time.deltaTime;
        if (t > bulletShotTime)
        {
            Vector3 pos = transform.position;
            for (int i = 0; i < bulletNumber; i++)
            {
                float x = (i - bulletNumber / 2) * xOffset;
                GameObject newobj = Instantiate(bullet, transform.position+new Vector3(x, 0, 0), transform.rotation);
                print(newobj.transform.position);
                Bullet newbullet = newobj.GetComponent<Bullet>();
                newbullet.vy = velocity.y;
            }
            t = 0;
        }
    }
    float t;
    public void InitWayShot()
    {
        t += Time.deltaTime;
        if (t >= bulletShotTime)
        {
            InitNWayBullets(velocity.x, velocity.y, bulletTheta, bulletNumber);
            for (int i = 0; i < bulletNumber; i++)
            {
                Quaternion bulletQua;
                if (bulletNumber % 2 != 0)
                { bulletQua = Quaternion.Euler(0, 0, (i - bulletNumber / 2) * -bulletTheta); }
                else if(i>bulletNumber/2-1)
                { bulletQua = Quaternion.Euler(0, 0, (i-bulletNumber/2)*(-bulletTheta)-bulletTheta); }
                else { bulletQua = Quaternion.Euler(0, 0, (i - bulletNumber / 2) * (-bulletTheta)); }
                GameObject newObj = Instantiate(bullet, transform.position, bulletQua);
                Bullet newBullet = newObj.GetComponent<Bullet>();

                newBullet.vx = vx[i];
                newBullet.vy = vy[i];
            }
            t = 0;
        }
    }
    private void FixedUpdate()
    {
        if (bullet_state == Bullet_State.InitWay)
        {
            InitWayShot();
        }
        else if (bullet_state == Bullet_State.Multiple)
        {
            MultipleShots();
        }
    }
}
