using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Explore : MonoBehaviour {
    //exp is Explore
    public GameObject expInfoUI;
    public Image[] textures = new Image[3];
    public SpotManager currentSpot;

    public void ShowExpInfo( SpotManager spot )
    {
        Color imagecolor = new Color( 225, 225, 225, 225 );
        Color blankcolor = new Color( 225, 225, 225, 0 );
        foreach ( var t in textures ) {
            t.color = blankcolor;
            t.GetComponentInChildren<Text>().text = "";
        }
        this.gameObject.SetActive( false );
        this.gameObject.SetActive( true );
        this.gameObject.transform.position = ( Input.mousePosition );
        RectTransform rect = this.GetComponent<RectTransform>();
        if ( rect.anchoredPosition.x > 460 ) {
            Vector2 pos;
            pos.x = 460;
            pos.y = rect.anchoredPosition.y;
            rect.anchoredPosition = pos;
        }
        for ( int i = 0; i < spot.ingredslist.Length; i++ ) {
            var ap = spot.ingredslist[i].amountAndProb;
            textures[i].color = imagecolor;
            textures[i].sprite = Resources.Load<Sprite>( $"Texture/Ingreds/{spot.ingredslist[i].Id}" );
            textures[i].GetComponentInChildren<Text>().text = $"{ap[0].amount}~{ap[ap.Length - 1].amount}";
        }
        currentSpot = spot;
    }
    static public void HideExpInfo()
    {
        foreach ( var item in GameObject.FindGameObjectsWithTag( "ExpInfo" ) ) {
            item.gameObject.SetActive( false );
        }
    }
    public void GoGathering()
    {
        currentSpot.isTargetSpot = true;
        GameObject.FindWithTag( "Player" ).GetComponent<CharacterMove>().GoForSpot( currentSpot );
        currentSpot.mask.SetActive( true );

        foreach ( var spotIngd in currentSpot.ingredslist ) {
            var Ingd = spotIngd.Draw();
            if ( Ingd != null ) {
                GatherResultUI.Ingredients.Add( Ingd );
            }
            //Debug.Log( $"The random number is {rand}" );
            //foreach ( var ap in spotIngd.amountAndProb ) {
            //        Inventory.Ingredients[spotIngd.Id].Put( ap.amount );
            //        GatherResultUI.resultID.Add( spotIngd.Id );
            //        GatherResultUI.resultAmount.Add( ap.amount );
            //        Debug.Log( $"Got {ap.amount} Inventory.Ingredients[ingred.ingredsId].Info.Name s" );
            //        break;
            //    }
            //}
        }
    }
}
