using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explore : MonoBehaviour
{
    //exp is Explore
    public GameObject expInfoUI;
    public Image[] textures = new Image[3];
    public SpotManager currentSpot;

    public void ShowExpInfo(SpotManager spot)
    {
        Color imagecolor = new Color(225, 225, 225, 225);
        Color blankcolor = new Color(225, 225, 225, 0);
        for (int i = 0; i < textures.Length; i++)
        {
            textures[i].color = blankcolor;
            textures[i].GetComponentInChildren<Text>().text = "";
        }
        this.gameObject.SetActive(false);
        this.gameObject.SetActive(true);
        this.gameObject.transform.position = (Input.mousePosition);
        RectTransform rect = this.GetComponent<RectTransform>();
        if (rect.anchoredPosition.x > 460)
        {
            Vector2 pos;
            pos.x = 460;
            pos.y = rect.anchoredPosition.y;
            rect.anchoredPosition = pos;
        }
        for (int i = 0; i < spot.ingredslist.Length; i++)
        {
            string path = "Texture/Ingreds/" + spot.ingredslist[i].ingredsId.ToString();
            int len = spot.ingredslist[i].amountAndProb.Length;
            string amountText = spot.ingredslist[i].amountAndProb[0].amount.ToString() + "~" +
                spot.ingredslist[i].amountAndProb[len - 1].amount.ToString();
            textures[i].color = imagecolor;
            textures[i].sprite = Resources.Load<Sprite>(path);
            textures[i].GetComponentInChildren<Text>().text = amountText;
        }
        currentSpot = spot;
    }
    static public void HideExpInfo()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("ExpInfo"))
        {
            item.gameObject.SetActive(false);
        }
    }
    public void GoGathering()
    {
        currentSpot.isTargetSpot = true;
        GameObject.FindWithTag("Player").GetComponent<CharacterMove>().GoForSpot(currentSpot);
        currentSpot.mask.SetActive(true);
        for (int i = 0; i < currentSpot.ingredslist.Length; i++)
        {
            double rand = Random.Range(0f, 1f);
            Debug.Log("The random number is " + rand.ToString());
            for (int j = 0; j < currentSpot.ingredslist[i].amountAndProb.Length; j++)
            {
                if (rand < currentSpot.ingredslist[i].amountAndProb[j].accProb)
                {
                    Inventory.Ingredients[currentSpot.ingredslist[i].ingredsId].Put(currentSpot.ingredslist[i].amountAndProb[j].amount);
                    GatherResultUI.resultID.Add(currentSpot.ingredslist[i].ingredsId);
                    GatherResultUI.resultAmount.Add(currentSpot.ingredslist[i].amountAndProb[j].amount);
                    Debug.Log("Got " + currentSpot.ingredslist[i].amountAndProb[j].amount.ToString() +
                        Inventory.Ingredients[currentSpot.ingredslist[i].ingredsId].Info.Name + "s");
                    break;
                }
            }
        }
    }
}
