using UnityEngine;

public class Item : MonoBehaviour
{
    [ItemDescription]
    [SerializeField] int itemCode;

    public int ItemCode { get { return itemCode; } set { itemCode = value; } }

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        if(itemCode != 0)
        {
            Init(itemCode);
        }
    }

    public void Init(int ItemCodeParam)
    {

    }
}
