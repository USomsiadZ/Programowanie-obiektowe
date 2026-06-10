using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class PongForm : Form
    {
        public PongForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // zapobiega migotaniu

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 20; // ms – częstotliwość odświeżania
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        int ballX = 150;
        int ballY = 50;
        int ballSize = 50;

        int dx = 4; // prędkość w poziomie
        int dy = 3; // prędkość w pionie

        System.Windows.Forms.Timer timer;

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Zmiana pozycji piłki
            ballX += dx;
            ballY += dy;

            // Odbicie od krawędzi formularza
            if (ballX <= 0 || ballX + ballSize >= this.ClientSize.Width)
                dx = -dx;

            if (ballY <= 0 || ballY + ballSize >= this.ClientSize.Height)
                dy = -dy;

            // Odśwież formularz
            this.Invalidate(); // wywoła OnPaint
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Rysowanie piłki
            g.FillEllipse(Brushes.Red, ballX, ballY, ballSize, ballSize);
        }
    }
}
