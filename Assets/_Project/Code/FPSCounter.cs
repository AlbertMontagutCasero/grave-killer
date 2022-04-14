using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace GraveKiller
{
    namespace UnityStandardAssets.Utility
    {
        [RequireComponent(typeof(Text))]
        public class FPSCounter : MonoBehaviour
        {
            private Text m_Text;

            private void Start()
            {
                m_Text = this.GetComponent<Text>();
            }

            private void Update()
            {
                this.m_Text.text = $"{(1.0f / Time.deltaTime)}\n{Time.frameCount / Time.time}";
            }
        }
    }
}
