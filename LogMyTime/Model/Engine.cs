using MouseKeyboardLibrary;
using System;
using System.Windows.Forms;

namespace LogMyTime.Model
{
    class Engine
    {
        private KeyboardHook keyboardHook = new KeyboardHook();
        private MouseHook mouseHook = new MouseHook();

        private int keyboardStrokes;
        private int mouseClicks;

        public Engine()
        {
            System.Diagnostics.Debug.WriteLine("Engine created");
            keyboardHook.KeyPress += new KeyPressEventHandler(KeyboardHook_KeyPress);
            mouseHook.DoubleClick += new EventHandler(MouseHook_Click);
            mouseHook.Click += new EventHandler(MouseHook_Click);
        }

        public void Start()
        {
            Reset();
            keyboardHook.Start();
            mouseHook.Start();
        }

        public void Stop()
        {
            keyboardHook.Stop();
            mouseHook.Stop();
        }

        private void KeyboardHook_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyboardStrokes++;
        }

        private void MouseHook_Click(object sender, EventArgs e)
        {
            mouseClicks++;
        }

        public int Clicks()
        {
            return mouseClicks;
        }

        public int Strokes()
        {
            return keyboardStrokes;
        }

        public void Reset()
        {
            mouseClicks = keyboardStrokes = 0;
        }
        
    }
}
