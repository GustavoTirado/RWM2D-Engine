using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motor_Grafico
{
    internal class Input
    {
        private Dictionary<Keys, bool> keyStates;

        public Input()
        {
            keyStates = new Dictionary<Keys, bool>();
        }

        public void KeyDown(KeyEventArgs e)
        {
            if (!keyStates.ContainsKey(e.KeyCode))
            {
                keyStates.Add(e.KeyCode, true);
            }
            else
            {
                keyStates[e.KeyCode] = true;
            }
        }

        public void KeyUp(KeyEventArgs e)
        {
            if (keyStates.ContainsKey(e.KeyCode))
            {
                keyStates[e.KeyCode] = false;
            }
        }

        public bool IsKeyPressed(Keys key)
        {
            return keyStates.ContainsKey(key) && keyStates[key];
        }
    }
}
