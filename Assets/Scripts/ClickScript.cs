using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PaintColour {Random, Blue, Pink, Yellow}
public class ClickScript : MonoBehaviour {

    public PaintColour paintColour;

    public Camera mainCamera;
    public Texture2D[] splashTextures;
    public Texture2D splashTexture;

    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit))
            {
                MyShaderBehavior script = hit.collider.gameObject.GetComponent<MyShaderBehavior>();
                if (null != script)
                {
                    script.PaintOn(hit.textureCoord, ChangePaintColour());
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
            paintColour = PaintColour.Random;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            paintColour = PaintColour.Blue;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            paintColour = PaintColour.Pink;
        if (Input.GetKeyDown(KeyCode.Alpha4))
            paintColour = PaintColour.Yellow;
    }


    //Returns a coloured texture from our array based on it's selected enum
    Texture2D ChangePaintColour()
    {
        switch(paintColour)
        {
            case PaintColour.Random:
                int rnd = Random.Range(0, splashTextures.Length);
                return splashTextures[rnd];
            case PaintColour.Blue:
                return splashTextures[0];
            case PaintColour.Pink:
                return splashTextures[1];
            case PaintColour.Yellow:
                return splashTextures[2];
            default:
                return splashTextures[0];

        }
    }
}
