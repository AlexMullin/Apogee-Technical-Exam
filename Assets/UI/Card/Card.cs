using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    /// <summary>
    /// This needs to be set to the correct menu before anything is done with the card.
    /// </summary>
    public static CardMenu menu;


    #region variables
    [Header("Objects")]
    [SerializeField] TMP_Text cardText;
    [SerializeField] TMP_Text cardAP;
    [SerializeField] TMP_Text cardDP;

    public string Text { get; private set; } = "CARD_NOT_SET";
    public int AP { get; private set; } = 0;
    public int DP { get; private set; } = 0;

    public int index = 0;


    /// <summary>
    /// References the current Menu's card database with the given id
    /// to set up the card's coloring and paramters.
    /// </summary>
    public void setupCard (int id)
    {
        //Set Values
        index = id;

        AP = Random.Range (menu.databaseCards.cards[id].apMin, menu.databaseCards.cards [id].apMax + 1);
        DP = Random.Range (menu.databaseCards.cards [id].dpMin, menu.databaseCards.cards [id].dpMax + 1);
        Text = createRandomString(8);

        
        //Set Text
        cardText.text = Text;
        cardAP.text = AP.ToString();
        cardDP.text = DP.ToString();


        //Card Visual Stuff
        UnityEngine.UI.Image img = GetComponent<UnityEngine.UI.Image>();
        img.color = menu.databaseCards.cards [index].cardColorBase;


        

    }

    /// <summary>
    /// Used by setupCard to generate a random string of alphanumeric characters
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    static string createRandomString (int size)
    {
        const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        string str = "";

        for ( int i = 0 ; i < size ; i++ )
        {
            str += characters [Random.Range (0, characters.Length)];
        }


        return str;
    }
    #endregion

    #region functions
    /// <summary>
    /// Displays the card information in the debug logs.
    /// 5 lines is recommended for best viewing
    /// </summary>
    private void DisplayInfo ()
    {
        Debug.Log (
            $"Card Clicked: {gameObject.name} | {gameObject.GetInstanceID()}" + 
            $"\n<color=#ffff>   Text</color>: {Text}" +
            $"\n<color=#11ff11>   AP</color>: {AP}" +
            $"\n<color=#ff0000>   DP</color>: {DP}"
            , this.gameObject);

    }


    #endregion

    #region EVENTS
    public event System.Action cardSelected;
    /// <summary>
    /// Displays the card info and fires off the cardSelected Event.
    /// It is linked ot SelectCard on the containing CardMenu
    /// </summary>
    public void onCardSelected ()
    {
        DisplayInfo ();
        cardSelected.Invoke ();
    }
    #endregion
}
