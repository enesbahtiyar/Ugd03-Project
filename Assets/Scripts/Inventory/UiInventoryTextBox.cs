using UnityEngine;
using TMPro;

public class UiInventoryTextBox : MonoBehaviour
{
    [SerializeField] TMP_Text textMeshProTop1;
    [SerializeField] TMP_Text textMeshProTop2;
    [SerializeField] TMP_Text textMeshProTop3;
    [SerializeField] TMP_Text textMeshProBottom1;
    [SerializeField] TMP_Text textMeshProBottom2;
    [SerializeField] TMP_Text textMeshProBottom3;


    public void SetTextBoxText(string textTop1, string textTop2, string textTop3, string textBottom1, string textBottom2, string textBottom3)
    {
        textMeshProTop1.text = textTop1;
        textMeshProTop2.text = textTop2;
        textMeshProTop3.text = textTop3;
        textMeshProBottom1.text = textBottom1;
        textMeshProBottom2.text = textBottom2;
        textMeshProBottom3.text = textBottom3;
    }
}
