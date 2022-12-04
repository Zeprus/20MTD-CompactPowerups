using UnityEngine;
using System.Linq;
using TMPro;

namespace CompactPowerups
{
    internal class PowerupCounter : MonoBehaviour
    {
        GameObject textObject;
        TextMeshProUGUI text;
        RectTransform rectTransform;
        private int count = 0;

        void Awake()
        {
            textObject = new GameObject("CounterText");
            textObject.transform.SetParent(gameObject.transform);

            rectTransform = textObject.AddComponent<RectTransform>();
            rectTransform.anchoredPosition= new Vector2(0f, 0f);
            rectTransform.sizeDelta = new Vector2(1.5f, 1.5f);

            text = textObject.AddComponent<TextMeshProUGUI>();
            text.font = Resources.FindObjectsOfTypeAll<TMP_FontAsset>().First((font) => font.name == "Lantern");
            text.UpdateFontAsset();
            text.alignment = TextAlignmentOptions.BottomRight;
            text.fontSize = 0.5f;
            text.color = new Color(253/255f,81/255f,97/255f);

            updateCount(1);
        }

        public void updateCount (int number)
        {
            this.count = number;
            if(count > 1) {
                this.text.text = count.ToString();
            } else {
             this.text.text = "";
            }
        }

        public int getCount() {
            return this.count;
        }
    }
}