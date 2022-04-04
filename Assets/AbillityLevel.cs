using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbillityLevel : MonoBehaviour
{
    public Abillity abillity;

    public GameObject levelPrefab;

    [SerializeField]
    List<GameObject> levels;

    HorizontalLayoutGroup hl;

    private void Start()
    {
        hl = GetComponent<HorizontalLayoutGroup>();
        for (int i = 0; i < abillity.level; i++)
        {
            GameObject clone = Instantiate(levelPrefab, transform);
            levels.Add(clone);
        }
        if (levels.Count >=3 && levels.Count <= 5)
        {
            //3, l 10, sp 17.5
            //4, l 0, sp 12.5
            //5, l -10, sp 7.5
            hl.padding.left = 40 - abillity.level*10;
            hl.spacing = 20 - abillity.level*2.5f;
        }
        else if(levels.Count == 1)
        {
            hl.padding.left = 45;
        }
        else if(levels.Count == 2)
        {
            hl.padding.left = 25;
            hl.spacing = 25;
        }
    }
}
