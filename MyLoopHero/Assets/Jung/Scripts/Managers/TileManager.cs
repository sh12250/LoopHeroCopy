using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public Sprite[] cemetary;
    public Sprite[] village;
    public Sprite[] bush;
    public Sprite[] cornfield;
    public Sprite cocoon;
    public Sprite mansion;
    public Sprite battlefield;
    public Sprite lighthouse;
    public Sprite rock;
    public Sprite mount;
    public Sprite bloodybush;
    public Sprite lamp;
    public Sprite swamp;
    public Sprite safe;
    public Sprite grass;

    private string scriptNames;

    private void Awake()
    {

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void ChangeTile(GameObject tile_, Sprite img_)
    {
        // name_ 을 체크해서 스프라이트 제공
        if (tile_ == null) { return; }

        tile_.GetComponentInChildren<SpriteRenderer>().sprite = img_;
    }
}
