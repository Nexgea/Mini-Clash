using UnityEngine;
using System.Collections;

public class RedAnimations : MonoBehaviour {
    public Sprite[] RedSprites;
    public SpriteRenderer animRenderer;
    public SpriteRenderer renderer;
    public Sprite selectedSprite;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    string spriteName = animRenderer.sprite.name;
    if (spriteName == "Extra sheet_0")
    {
        foreach (Sprite s in RedSprites)
        {
            if (s.name == "Extra sheet 2_0")
            {
                selectedSprite = s;
            }
        }
        renderer.sprite = selectedSprite;
    }
    if (spriteName == "Extra sheet_1")
    {
        foreach (Sprite s in RedSprites)
        {
            if (s.name == "Extra sheet 2_1")
            {
                selectedSprite = s;
            }
        }
        renderer.sprite = selectedSprite;
    }
    if (spriteName == "Extra sheet_2")
    {
        foreach (Sprite s in RedSprites)
        {
            if (s.name == "Extra sheet 2_2")
            {
                selectedSprite = s;
            }
        }
        renderer.sprite = selectedSprite;
    }
    if (spriteName == "Extra sheet_3")
    {
        foreach (Sprite s in RedSprites)
        {
            if (s.name == "Extra sheet 2_3")
            {
                selectedSprite = s;
            }
        }
        renderer.sprite = selectedSprite;
    }
    else
    {
        char ch = '2';
        spriteName = ReplaceAtIndex(8, ch, spriteName);
        Debug.Log(spriteName);
        foreach (Sprite s in RedSprites)
        {
            if (s.name == spriteName)
            {
                selectedSprite = s;
            }
        }
        renderer.sprite = selectedSprite;
    }
	}
    string ReplaceAtIndex(int i, char value, string word)
    {
        char[] letters = word.ToCharArray();
        letters[i] = value;
        return new string(letters);
    }
}
