using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GatherResultUI : MonoBehaviour
{
    public Image[] textures = new Image[3];
    
    static public List<Ingredient> Ingredients = new List<Ingredient>();
    public void ShowResult()
    {
        Color imagecolor = new Color(225, 225, 225, 225);
        Color blankcolor = new Color(225, 225, 225, 0);
        for (int i = 0; i < textures.Length; i++)
        {
            textures[i].color = blankcolor;
            textures[i].GetComponentInChildren<Text>().text = "";
        }
        this.gameObject.SetActive(true);
        for (int i = 0; i < Ingredients.Count; i++)
        {
            var ingd = Ingredients[i];
            string path = $"Texture/Ingreds/{ingd.Info.Id}";
            textures[i].color = imagecolor;
            textures[i].sprite = Resources.Load<Sprite>(path);
            textures[i].GetComponentInChildren<Text>().text = $"{ingd.Count}";
        }
    }
    static public void ResultConfirm()
    {
        GameObject.Find("GatherResult").SetActive(false);
        GameObject.Find("Mask").SetActive(false);
        GameObject.Find("UI-ExpInfo").SetActive(false);
       Ingredients.Clear();
    }
}
