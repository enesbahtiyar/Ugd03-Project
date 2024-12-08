[System.Serializable]
public struct CharacterAttribute
{
    public CharacterPartAnimator characterPartAnimator;
    public PartVariantColor partVariantColor;
    public PartVariantType partVariantType;

    public CharacterAttribute(CharacterPartAnimator characterPartAnimator, PartVariantColor partVariantColor, PartVariantType partVariantType)
    {
        this.characterPartAnimator = characterPartAnimator;
        this.partVariantColor = partVariantColor;
        this.partVariantType = partVariantType;
    }
}
