using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{
    public Canvas canvasHUD;
    public List<GameObject> healthBarImages;

    public Player player;
    void Start()
    {        
        for(int i = 0; i < player.Health; i++)
        {
            GameObject imgObject = new GameObject($"BarHealth{i+1}");

            RectTransform trans = imgObject.AddComponent<RectTransform>();
            trans.transform.SetParent(canvasHUD.transform); // setting parent
            trans.localScale = Vector3.one;
            trans.anchoredPosition = new Vector2(i+20, i+20); // setting position, will be on center
            trans.sizeDelta = new Vector2(150, 200); // custom size

            Image image = imgObject.AddComponent<Image>();            
            Texture2D tex = Resources.Load<Texture2D>("Assets/SpriteSheets/ui/life_unit.png");
            image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            imgObject.transform.SetParent(canvasHUD.transform);

            healthBarImages.Add(imgObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isHurt)
        {            
            Image image = healthBarImages[player.Health - 1].GetComponent<Image>();
            Texture2D tex = Resources.Load<Texture2D>("black");
            image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        }
    }
}
