using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 3f;
    public static int lvl = 0;
    public static int keysRequired = 1;
    public int health = 5;
    public int damage = 1;
    public int keys = 0;
    private GameObject animatedPlayer;

    public GameObject dyingScriptObj;
    public GameObject winingScriptObj;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private Text lvltext;
    private Text keytext;
    private Text goaltext;
    private Die dyingScript;
    private Win winingScript;


    public GameObject hint;
    public GameObject lvlTextObj;
    public GameObject keysTextObj;
    public GameObject healthManager;

    private Animator animator;
    private Characteristics healthViewer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lvltext = lvlTextObj.GetComponent<Text>();
        keytext = keysTextObj.GetComponent<Text>();
        animatedPlayer = transform.GetChild(0).gameObject;
        animator = animatedPlayer.GetComponent<Animator>();
        healthViewer = healthManager.GetComponent<Characteristics>();
        dyingScript = dyingScriptObj.GetComponent<Die>();
        winingScript = winingScriptObj.GetComponent<Win>();

        keytext.text = "Keys needed: " + keysRequired;
        if (lvl == 0)
        {
            hint.SetActive(true);
            lvltext.enabled = false;
        }
        else
        {
            hint.SetActive(false);
            lvltext.enabled = true;
            lvltext.text = "LVL" + lvl;
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            dyingScript.isDied = true;
        }
        
<<<<<<< HEAD:Assets/Player.cs
            rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * speed;
            if(Input.GetKey("r"))
            {
            Dice.rolling = true;
        }

=======
        if (rb.velocity.magnitude < 0.1f && animator.GetBool("isRunning"))
        {
            animator.SetBool("isRunning", false);
        }
        else if (rb.velocity.magnitude > 0.1f && !animator.GetBool("isRunning"))
        {
            animator.SetBool("isRunning", true);
        }

        if((Input.GetKey("r")) && (Dice.rolling == false))
        {
            Dice.rolling = true;
        }
        healthViewer.amount = health;
    }
    
    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;
>>>>>>> main:Assets/Scripts/Player.cs
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var projectile = col.gameObject.GetComponent<Projectile>();
        if (projectile && projectile.enemy)
        {
            health -= (int)projectile.damage;
        }

        if (col.CompareTag("Door") && keys >= keysRequired)
        { 
        keys = 0;
        lvl += 1;
        switch (lvl)
        {
            case 3:
                keysRequired += 1;
                break;
                case 5:
                keysRequired += 1;
                break;
            case 7:
                keysRequired += 1;
                break;
            case 8:
                 keysRequired += 1;
                 break;
            case 9:
                keysRequired += 1;
                break;
            default:
                break;
            }
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            health--;
        }
    }
}
