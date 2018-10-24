using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float moveSpeed = 3;
    //一开始时间
    public float myTime = 0.0f;
    //开火间隔时间
    public float deltatime = 0.5f;
    //下次开火时间
    public float nextFire = 0.5f;
    public float h;
    public float v;
    public GameObject bulletPrefeb;
    private SpriteRenderer image;
    public Sprite[] tankSprite;//上右下左
    // Use this for initialization
    private void Awake()
    {
        image = this.GetComponent<SpriteRenderer>();
    }
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        attack();
    }
    void FixedUpdate()
    {
        move();
        
    }
    //坦克移动
    private void move() {
         h = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime);
        if (h > 0)
        {
            image.sprite = tankSprite[1];
        }
        else if (h < 0)
        {
            image.sprite = tankSprite[3];
        }
        if (h != 0)
        {
            return;
        }
         v = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime);
        if (v > 0)
        {
            image.sprite = tankSprite[0];
        }
        else if (v < 0)
        {
            image.sprite = tankSprite[2];
        }
    }
    //坦克攻击
    private void attack(){
        myTime += Time.deltaTime;
        if (Input.GetButton("Fire1")&&myTime>nextFire) {
            nextFire = myTime + deltatime;
            
            
            Instantiate(bulletPrefeb,transform.position,transform.rotation);
            //重置下发开火时间为0.5f后
            nextFire = nextFire - myTime;
            //设置当前已开火时间为0；
            myTime = 0.0f;
           
        }
    }
}
