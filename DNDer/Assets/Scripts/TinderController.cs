using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TinderController : MonoBehaviour
{
    public SpriteRenderer mySprite;
    public Texture2D[] textures;
    public int currentTextureIndex = 0;

    public void ChangeTexture()
    {
        currentTextureIndex++;
        if (currentTextureIndex >= textures.Length)
        {
            currentTextureIndex = 0;
        }
        Texture2D newTexture = textures[currentTextureIndex];
        Sprite originalSprite = mySprite.sprite;
        Vector2 pivot = new Vector2(originalSprite.rect.x / originalSprite.rect.width, originalSprite.rect.y / originalSprite.rect.height);
        Sprite newSprite = Sprite.Create(newTexture, originalSprite.rect, pivot);

        mySprite.sprite = newSprite;
        
        //Sprite newSprite = Sprite.Create(newTexture, new Rect(0, 0, newTexture.width, newTexture.height), Vector2.zero);
        //Vector2 originalPivot = mySprite.sprite.pivot;
        //newSprite.pivot = originalPivot;
        //mySprite.sprite = newSprite;
        //mySprite.transform.position = new Vector3((float)-19.3901997, (float)7.7020998, (float)-0.922304749);
    }
}
