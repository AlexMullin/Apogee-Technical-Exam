using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Creates and fills out the table with cards
/// </summary>
public class CardMenu : MonoBehaviour
{
    #region variables
    [Header("Objects")]
    private ScrollRect objectCardContainer;

    public GameObject prefabCard;
    public Database_Cards databaseCards;

    [Header("Settings")]
    public int cardsToAdd = 50;

    [Header("Variables")]
    Card currentCard;
    #endregion


    #region Functions


    void CreateCard (int index)
    {
        Card c = Instantiate(prefabCard, objectCardContainer.content).GetComponent<Card>();

        c.setupCard (index);

        c.cardSelected += () => SelectCard (c);
    }

    /// <summary>
    /// Highlights a new card and returns the previous one to its orignial color.
    /// When a card is clicked, it calls this via an event.
    /// </summary>
    /// <param name="c"></param>
    public void SelectCard (Card c)
    {
        if(currentCard != null)
        currentCard.GetComponent<Image> ().color = databaseCards.cards [currentCard.index].cardColorBase;

        currentCard = c;

        c.GetComponent<Image> ().color = databaseCards.cards [c.index].cardColorSelected;
    }

    #endregion

    #region SETUP

    /// <summary>
    /// Set a reference to the content container
    /// </summary>
    private void Awake ()
    {
        objectCardContainer = GetComponent<ScrollRect> ();
    }

    /// <summary>
    /// Populates the menu with cards and 
    /// Sets the Card.menu reference to this menu to this current Menu on load
    /// 
    /// </summary>
    private void Start ()
    {
        //Allows the cards in the menu to reference this menu for the scriptableObject to get indexes
        Card.menu = this;

        //Remove the template cards from content
        foreach (Transform t in objectCardContainer.content )
        {
            Destroy (t.gameObject);
        }

        //For each of the cards to add, create a card and put them into content.
        if ( databaseCards.cards.Length > 0 )
            for ( int i = 0 ; i < cardsToAdd ; i++ )
            {
                CreateCard (Random.Range (0, databaseCards.cards.Length));
            }

        else Debug.LogError ("Cards Database has no cards");

    }

    #endregion
}
