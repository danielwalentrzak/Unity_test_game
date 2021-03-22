using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovment : MonoBehaviour
{
    public static PlayerMovment singleton;
    private Rigidbody2D rb;
    [HideInInspector] public float moveH, moveV;
    public float ms = 3.0f;
    public float hp = 120.0f;
    public float maxhp = 120.0f;
    public float armor = 0f;
    private bool turnedright = true;
    public GameObject endmenu;
    public bool alive;
    public int floors;
    public int maxfloor = 0;
    public float dashmv;
    [SerializeField] private float dashtime;
    [SerializeField] private float startdashtime;
    public float dashcd;
    public float dashcdmax;
    private bool isdashing;
    public bool upgradeddash;
    Vector3 save;
    private bool saved;
   

    // Start is called before the first frame update

    private void Awake()
    {
        alive = true;
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            if (singleton != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        floors = 1;
        saved = false;
        rb = GetComponent<Rigidbody2D>();
        dashtime = startdashtime;
        dashcdmax = 3f;
        upgradeddash = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dashcd <= 0)
        {
            //   save = null;
        }
        rb.velocity = new Vector2(moveH, moveV);
        if (dashcd > 0)
        {
            dashcd -= Time.deltaTime;
        }
        if (hp <= 0)
        {
            alive = false;

            gameObject.GetComponentInChildren<Animator>().Play("Player_Death");

        }
        if (alive == true)
        {


            gameObject.GetComponentInChildren<Animator>().SetFloat("Speed", Mathf.Abs(moveH) + Mathf.Abs(moveV));

            if (turnedright == true && Input.GetKeyDown(KeyCode.A))
            {
                turnedright = false;
                Vector3 localx = transform.localScale;
                localx.x *= -1;
                transform.localScale = localx;
            }
            if (turnedright == false && Input.GetKeyDown(KeyCode.D))
            {
                turnedright = true;
                Vector3 localx = transform.localScale;
                localx.x *= -1;
                transform.localScale = localx;
            }
            moveH = Input.GetAxisRaw("Horizontal") * ms;
            moveV = Input.GetAxisRaw("Vertical") * ms;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashcd <= 0)
        {
            if (upgradeddash && saved == false)
            {
                save = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                saved = true;
                Debug.Log(save);
            }

            isdashing = true;
            dashtime = startdashtime;
            rb.velocity = Vector2.zero;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashcd > 0 && upgradeddash && saved)
        {
            gameObject.transform.position = save;
            saved = false;
        }
        if (isdashing)
        {
            dashcd = dashcdmax;
            Physics2D.IgnoreLayerCollision(0, 8, true);
            if (moveH < 0)
            {
                rb.velocity = Vector2.left * dashmv;
            }
            if (moveH > 0)
            {
                rb.velocity = Vector2.right * dashmv;
            }
            if (moveV > 0)
            {
                rb.velocity = Vector2.up * dashmv;
            }
            if (moveV < 0)
            {
                rb.velocity = Vector2.down * dashmv;
            }
            if (moveH < 0 && moveV > 0)
            {
                rb.velocity = new Vector2(moveH * dashmv / ms / 2, moveV * dashmv / ms / 2);
            }
            if (moveH > 0 && moveV > 0)
            {
                rb.velocity = new Vector2(moveH * dashmv / ms / 2, moveV * dashmv / ms / 2);
            }
            if (moveV < 0 && moveH < 0)
            {
                rb.velocity = new Vector2(moveH * dashmv / ms / 2, moveV * dashmv / ms / 2);
            }
            if (moveV < 0 && moveH > 0)
            {
                rb.velocity = new Vector2(moveH * dashmv / ms / 2, moveV * dashmv / ms / 2);
            }
            dashtime -= Time.deltaTime;
            if (dashtime <= 0)
            {
                isdashing = false;
                Physics2D.IgnoreLayerCollision(0, 8, false);
            }
        }

    }
    private void FixedUpdate()
    {

    }

    public void Smierc()
    {
        SceneManager.LoadScene("Start");
        Destroy(gameObject);
    }
    public void Takedmg(float dmg)
    {
        if ((dmg - armor) > 0)
        {
            hp -= dmg - armor;
        }
        else
            hp = hp;
    }
}