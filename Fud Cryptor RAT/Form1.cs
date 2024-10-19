using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fud_Cryptor_RAT
{
    public partial class Form1 : Form
    {
        private List<Particle> particles = new List<Particle>();
        private Random random = new Random();
        private Timer timer = new Timer();
        public int ParticleCount = 200;

        public Form1()
        {
            this.AutoScaleMode = AutoScaleMode.None;
            this.DoubleBuffered = true;
            this.Size = new Size(800, 600);
            this.BackColor = Color.Black;

            timer.Interval = 10;
            timer.Tick += Timer_Tick;
            timer.Start();

            this.Paint += Form1_Paint;
            InitializeComponent();
            InitializeParticles();
            this.Resize += Form1_Resize;
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            //this.ClientSize = new Size(628, 450);
        }

        private void InitializeParticles()
        {
            for (int i = 0; i < ParticleCount; i++)
            {
                CreateParticle();
            }
        }

        private void CreateParticle()
        {
            float x = (float)random.NextDouble() * this.ClientSize.Width;
            float y = (float)random.NextDouble() * this.ClientSize.Height;
            float speed = (float)random.NextDouble() *100 + 100;
            float size = (float)random.NextDouble() * 2 + 1;
            int brightness = random.Next(128, 150);
            Color color = Color.FromArgb(brightness, brightness, brightness);

            particles.Add(new Particle(new PointF(x, y), speed, size, color));
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateParticles();
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var particle in particles)
            {
                particle.Draw(e.Graphics);
            }
        }

        private void UpdateParticles()
        {
            float deltaTime = 0.016f;

            foreach (var particle in particles)
            {
                particle.Update(deltaTime, this.ClientSize.Height);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private PrivateFontCollection pfc = new PrivateFontCollection();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCustomFont();
        }
        private void LoadCustomFont()
        {
            string fontPath = "C:\\Users\\anthe\\source\\repos\\Fud Cryptor RAT\\Fud Cryptor RAT\\Fonts\\Raleway-SemiBold.ttf";

            pfc.AddFontFile(fontPath);
            ApplyCustomFont();
        }
        private void ApplyCustomFont()
        {
            Font customFont = new Font(pfc.Families[0], 11, FontStyle.Regular);
            guna2Button1.Font = customFont;
            guna2Button2.Font = customFont;
            guna2Button3.Font = customFont;

            label1.Font = customFont;
            label2.Font = customFont;
            label3.Font = customFont;
            label4.Font = customFont;
            label5.Font = customFont;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }
    }
}
