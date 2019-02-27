using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Texture2D splashTexture;


    private void OnCollisionEnter(Collision collision)
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(collision.contacts[0].point - collision.contacts[0].normal, collision.contacts[0].normal);
        if (Physics.Raycast(ray, out hit))
        {
            MyShaderBehavior script = collision.collider.gameObject.GetComponent<MyShaderBehavior>();
            if (null != script)
            {
                script.PaintOn(hit.textureCoord, splashTexture);
            }
        }
    }

}
