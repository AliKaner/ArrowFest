using TMPro;
using UnityEngine;

[System.Serializable]
public class DoorEffect : MonoBehaviour
{
    public enum Effect
    {
        Addition,
        Extraction,
        Division,
        Multiplication
    }

    private string _sign;
    public Effect selectedEffect;
    public int effectAmount;
    [SerializeField] private TextMeshProUGUI text;
    public Material[] materials;
    public bool isUsed = false;
    private void SetStats(Effect effect)
    {
        switch (effect)
        {
            case Effect.Addition:
                gameObject.GetComponent<MeshRenderer>().material = materials[0];
                _sign = "+";
                break;
            case Effect.Extraction:
                gameObject.GetComponent<MeshRenderer>().material = materials[1];
                _sign = "-";
                break;
            case Effect.Division:
                gameObject.GetComponent<MeshRenderer>().material = materials[1];
                _sign = "÷";
                break;
            case Effect.Multiplication:
                gameObject.GetComponent<MeshRenderer>().material = materials[0];
                _sign = "x";
                break;
        }
    }
    private void TextSetter()
    {
        SetStats(selectedEffect);
        text.text= _sign + effectAmount;
    }
    private void Awake()
    {
        TextSetter();
    }
}
