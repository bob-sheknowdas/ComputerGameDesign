using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene5VideoController : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
    public GameObject friend1;
    public GameObject friend2;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject fire;
    public GameObject molotow;
    public GameObject fatbat;
    public GameObject fireball;
    public Text textfield;
    public Image dragonImage;
    public Image ninjaImage;
    public AudioClip swordSound;
    public AudioClip swordBrakeSound;
    private AudioSource myAudioSource;
    private GameObject panel;
    private GameObject[] goodGuys = new GameObject[3];

    // Use this for initialization
    void Start ()
    {
        myAudioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        panel = GameObject.FindGameObjectWithTag("SpeechPanel");
        goodGuys[0] = player1;
        goodGuys[1] = friend1;
        goodGuys[2] = friend2;
        for(int i = 0; i < goodGuys.Length; i++)
        {
            goodGuys[i].GetComponent<Animator>().SetBool("grounded", true);
        }
        StartCoroutine(RunScene());
    }

    IEnumerator RunScene()
    {
        yield return StartCoroutine(AllMove(-30));
        yield return new WaitForSeconds(0.2f);
        yield return StartCoroutine(ShowText(ninjaImage, "Over there!!\nThat is where the monster lives!!!"));
        yield return new WaitForSeconds(0.2f);
        yield return StartCoroutine(ShowText(dragonImage, "Morning guys.\nHow may I be of assista..."));
        yield return new WaitForSeconds(0.2f);
        yield return StartCoroutine(ShowText(ninjaImage, "Shut up, monster!!\nHere! Eat shit!!"));
        yield return StartCoroutine(ThrowMolotow());
        yield return new WaitForSeconds(0.2f);
        yield return StartCoroutine(ShowText(dragonImage, "Oy!!\nWTF?!?"));
        yield return new WaitForSeconds(0.2f);
        yield return StartCoroutine(ShowText(ninjaImage, "Die, bastard!!"));
        yield return StartCoroutine(PlayerAttack());
        yield return new WaitForSeconds(0.2f);
        yield return StartCoroutine(ShowText(dragonImage, "HaHa!!\nYour cute little swords can't hurt me!\nThey just brake at my armor..."));
        yield return StartCoroutine(EnemyFly());
        yield return StartCoroutine(ShowText(ninjaImage, "Shit, where did he go?"));
        yield return StartCoroutine(Move());
        yield return StartCoroutine(ShowText(dragonImage, "Now it is my turn!\nSuckers!!"));
        yield return StartCoroutine(EnemyAttack());
        player2.GetComponent<Animator>().SetTrigger("fall");
        player2.GetComponent<Rigidbody2D>().velocity = new Vector2(15, 20);
        while (true)
        {
            Debug.Log(player2.transform.position);
            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator AllMove(float xPosition)
    {
        for (int i = 0; i < goodGuys.Length; i++)
        {
            goodGuys[i].GetComponent<Animator>().SetBool("running", true);
        }
        while (friend1.transform.position.x < xPosition)
        {
            for (int i = 0; i < goodGuys.Length; i++)
            {
                goodGuys[i].GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
            }
            yield return new WaitForSeconds(0.1f);
        }
        for (int i = 0; i < goodGuys.Length; i++)
        {
            goodGuys[i].GetComponent<Animator>().SetBool("running", false);
        }
    }

    IEnumerator ShowText(Image image, string text)
    {
        panel.GetComponent<Image>().enabled = true;
        textfield.text = text;
        image.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(3f);
        panel.GetComponent<Image>().enabled = false;
        textfield.text = "";
        image.GetComponent<Image>().enabled = false;
    }

    IEnumerator ThrowMolotow()
    {
        molotow.SetActive(true);
        while (molotow.transform.position.x < -17)
        {
            float velocityY = -4;
            if (molotow.transform.position.x <= -25)
                velocityY = 4;
            else if (molotow.transform.position.x <= -23)
                velocityY = 2;
            else if (molotow.transform.position.x <= -21)
                velocityY = 0;
            else if (molotow.transform.position.x <= -19)
                velocityY = -2;
            molotow.GetComponent<Rigidbody2D>().velocity = new Vector2(5, velocityY);
            molotow.transform.Rotate(0, 0, 10 * molotow.transform.position.x);
            yield return new WaitForSeconds(0.1f);
        }
        fatbat.SetActive(true);
        fatbat.GetComponent<Animator>().SetTrigger("forcedExplode");
        molotow.SetActive(false);
        fire.SetActive(true);
    }

    IEnumerator PlayerAttack()
    {
        player1.GetComponent<Animator>().SetBool("running", true);
        while (player1.transform.position.x < enemy1.transform.position.x - 2)
        {
            player1.GetComponent<Rigidbody2D>().velocity = new Vector2(7, 0);
            yield return new WaitForSeconds(0.1f);
        }
        player1.GetComponent<Animator>().SetBool("running", false);
        player1.GetComponent<Animator>().SetTrigger("attacking");
        myAudioSource.PlayOneShot(swordSound);
        yield return new WaitForSeconds(0.2f);
        myAudioSource.PlayOneShot(swordBrakeSound);
        player2.transform.position = player1.transform.position;
        player2.SetActive(true);
        player2.GetComponent<Animator>().SetBool("grounded", true);
        Destroy(player1);
    }

    IEnumerator EnemyFly()
    {
        enemy2.SetActive(true);
        enemy1.SetActive(false);
        enemy2.GetComponent<Rigidbody2D>().velocity = new Vector2(-3.8f, 3f);
        while (enemy2.transform.position.x > -32)
        {
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Move()
    {
        player2.GetComponent<Animator>().SetBool("running", true);
        player2.transform.localScale = new Vector3(-0.5587515f, 0.5905936f, 1);
        while (player2.transform.position.x > friend1.transform.position.x + 2)
        {
            player2.GetComponent<Rigidbody2D>().velocity = new Vector2(-4, 0);
            yield return new WaitForSeconds(0.1f);
        }
        player2.GetComponent<Animator>().SetBool("running", false);
    }

    IEnumerator EnemyAttack()
    {
        enemy2.transform.Rotate(0, 0, 225);
        enemy2.transform.localScale = new Vector3(1, 1, 1);
        enemy2.transform.position = new Vector3(player2.transform.position.x - 12f, player2.transform.position.y + 8f, 0);
        enemy2.GetComponent<Rigidbody2D>().velocity = new Vector2(4f, 0);
        while (enemy2.transform.position.x < friend2.transform.position.x)
        {
            yield return new WaitForSeconds(0.1f);
        }
        Vector2 position = enemy2.transform.position;
        position.x = position.x + 1f;
        position.y = position.y - 1f;
        GameObject.Instantiate(fireball, new Vector2(position.x, position.y), Quaternion.AngleAxis(90, Vector3.forward));
        while (enemy2.transform.position.x < friend2.transform.position.x+5)
        {
            yield return new WaitForSeconds(0.1f);
        }
        friend1.GetComponent<Animator>().SetTrigger("hit");
        friend2.GetComponent<Animator>().SetTrigger("hit");
    }
}
