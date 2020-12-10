using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{

    //Level attributes
    public GameObject Level;

    //Rotation
    private Quaternion CurrentRotation = new Quaternion(0f, 0f, 0f, 1f);
    public float speedRotate;
    private Quaternion target = new Quaternion(0f, 0f, 0f, 1f);

    public Quaternion left;
    public Quaternion right;
    public Button LeftButton;
    public Button RightButton;

    //Player attributes
    public GameObject Player;
    private Rigidbody2D rb;

    //Counters
    public Text MovesText;
    public float Moves;
    public Text ItemsText;
    public static float Items;
    public float TotalItems;
    private float timeLeft = 3.0f;

    //End level
    public GameObject EndLevelMenu;
    public Text TotalMovesText;
    public float GivenMoves;
    public Text WinLoseText;
    public GameObject NextLevelButton;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Start()
    {
        Items = 0;
        Moves = 0;
        rb = Player.GetComponent<Rigidbody2D>();
        rb.gravityScale = 1;
        MovesText.text = "Moves: 0 / " + GivenMoves;
        ItemsText.text = "0 / " + TotalItems;
        EndLevelMenu.SetActive(false);
    }

    IEnumerator RotateObjectLeft()
    {
        bool ltarget = false;
        target = right * CurrentRotation;
        Moves += 1;
        timeLeft = 1f;
        //Start rotating
        while (ltarget == false)
        {
            RightButton.interactable = false;
            LeftButton.interactable = false;
            rb.gravityScale = 0;
            Level.transform.rotation = Quaternion.RotateTowards(CurrentRotation, target, speedRotate * Time.deltaTime);

            //don't get stuck

            if (CurrentRotation == target)
            {
                RightButton.interactable = true;
                LeftButton.interactable = true;
                rb.gravityScale = 1;
                ltarget = true;
                Level.transform.rotation = Quaternion.Slerp(CurrentRotation, target, 1f);
            }
            if (timeLeft < 0)
            {
                RightButton.interactable = true;
                LeftButton.interactable = true;
                rb.gravityScale = 1;
                ltarget = true;
                Level.transform.rotation = Quaternion.Slerp(CurrentRotation, target, 1f);
            }
            yield return null;
        }
    }

    IEnumerator RotateObjectRight()
    {
        bool rtarget = false;
        target = CurrentRotation * left;
        Moves += 1;
        timeLeft = 1f;
        //Start rotating
        while (rtarget == false)
        {
            RightButton.interactable = false;
            LeftButton.interactable = false;
            rb.gravityScale = 0;
            Level.transform.rotation = Quaternion.RotateTowards(CurrentRotation, target, speedRotate * Time.deltaTime);

            if (CurrentRotation == target)
            {
                RightButton.interactable = true;
                LeftButton.interactable = true;
                rb.gravityScale = 1;
                rtarget = true;
                Level.transform.rotation = Quaternion.Slerp(CurrentRotation, target, 1f);
            }
            if (timeLeft < 0)
            {
                RightButton.interactable = true;
                LeftButton.interactable = true;
                rb.gravityScale = 1;
                rtarget = true;
                Level.transform.rotation = Quaternion.Slerp(CurrentRotation, target, 1f);
            }
            yield return null;
        }

    }

    void Update()
    {
        //Update counters
        CurrentRotation = Level.transform.rotation;
        MovesText.text = "Moves: " + Moves + " / " + GivenMoves;
        ItemsText.text = "Items: " + Items + " / " + TotalItems;
        //make sure buttons don't break
        timeLeft -= Time.deltaTime;

        //Win condition
        if (Items == TotalItems)
        {
            EndLevelMenu.SetActive(true);
            WinLoseText.text = "You Won!";
            TotalMovesText.text = "Total Moves: " + Moves;
            NextLevelButton.SetActive(true);
            Time.timeScale = 0;
        }

        //Lose condition
        if (Moves > GivenMoves)
        {
            EndLevelMenu.SetActive(true);
            WinLoseText.text = "You Lost!";
            TotalMovesText.text = "Too Many Moves!";
            NextLevelButton.SetActive(false);
            Time.timeScale = 0;
        }
    }

    //Functions called onClick()
    public void RotateLeft()
    {
        StartCoroutine(RotateObjectLeft());
    }

    public void RotateRight()
    {
        StartCoroutine(RotateObjectRight());
    }

    public void Retry()
    {
        int ActiveScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(ActiveScene);
    }

    public void NextLevel()
    {
        int ActiveScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(ActiveScene + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}