using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel; //Added by Jont
    public GameObject draggingObject;
    public GameObject currentContainer;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        gameOverPanel.SetActive(false); //A pannel i added to visualize loosing and giving the player the option to restart
    }

    public void PlaceObject()
    {
        if (draggingObject != null && currentContainer != null)
        {
            Instantiate(draggingObject.GetComponent<ObjectDragged>().card.object_game, currentContainer.transform);
            currentContainer.GetComponent<ObjectContainer>().isFull = true;
        }
    }
    /// <summary>
    /// Everything below is added by me, JONT!
    /// Ill add comments to make this as readable as possible!
    /// </summary>
    /// 
    public void RestartTheGame() //Called from a button
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private void GameOver() //End the game
    {
        //Play some message or sound effect or something
        gameOverPanel.SetActive(true);
        //Load next scene
    }

    private void OnEnable() //Happens as this object becomes active in the game
    {
        scrDinoMovement.OnDinoGoalReached += GameOver; //Subscribes to this event with the method "GameOver". GameOver will then trigger
        //whenever this event happens. This event is triggered in the class "scrDinoMovement". 
    }

    private void OnDisable() //Happens as(if) this object becomes unactive in the game
    {
        scrDinoMovement.OnDinoGoalReached -= GameOver; //Desubscribes from the event over. (To prevent data leakage in case this class does
        //not exist. Should never happen, but you never know...)
    }

}
