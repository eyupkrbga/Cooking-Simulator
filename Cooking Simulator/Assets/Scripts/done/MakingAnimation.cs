using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingAnimation : MonoBehaviour
{
    float minCoffeeScale = 56f, maxCoffeeScale = 65f, minPotatoScale = 176f, maxPotatoScale = 200f, minSandwichScale = 150f, maxSandwichScale = 300f, changeSpeed = 2f;

    public ProductMaking productMaking;

    public void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            if(productMaking.isProductMaking[i])
            {
                float newScale = Mathf.Lerp(minCoffeeScale, maxCoffeeScale, Mathf.PingPong(Time.time * changeSpeed, 1));
                productMaking.stands[i].transform.localScale = new Vector3(productMaking.stands[i].transform.localScale.x, productMaking.stands[i].transform.localScale.y, newScale);
            }
            else
            productMaking.stands[i].transform.localScale = new Vector3(productMaking.stands[i].transform.localScale.x, productMaking.stands[i].transform.localScale.y, minCoffeeScale);
        }
        for (int j = 3; j < 6; j++)
        {
            if(productMaking.isProductMaking[j])
            {
                float newScale = Mathf.Lerp(minPotatoScale, maxPotatoScale, Mathf.PingPong(Time.time * changeSpeed, 1));
                productMaking.stands[j].transform.localScale = new Vector3(productMaking.stands[j].transform.localScale.x, productMaking.stands[j].transform.localScale.y, newScale);
            }
            else 
            productMaking.stands[j].transform.localScale = new Vector3(productMaking.stands[j].transform.localScale.x, productMaking.stands[j].transform.localScale.y, minPotatoScale);
        }
        for (int k = 6; k < 9; k++)
        {
            if(productMaking.isProductMaking[k])
            {
                float newScale = Mathf.Lerp(minSandwichScale, maxSandwichScale, Mathf.PingPong(Time.time * changeSpeed, 1));
                productMaking.stands[k].transform.localScale = new Vector3(productMaking.stands[k].transform.localScale.x, productMaking.stands[k].transform.localScale.y, newScale);
            }
            else
            productMaking.stands[k].transform.localScale = new Vector3(productMaking.stands[k].transform.localScale.x, productMaking.stands[k].transform.localScale.y, minSandwichScale);
        }
    }
}
