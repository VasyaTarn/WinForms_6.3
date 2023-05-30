namespace WinForms_6._3
{
    public partial class Form1 : Form
    {
        private Color[] colors;
        private int currentColorIndex;

        public Form1()
        {
            InitializeComponent();

            timer1.Tick += timer1_Tick;
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Start();

            colors = new Color[] {Color.Black, Color.Red, Color.Yellow, Color.Cyan, Color.Blue, Color.Pink, Color.White};

            currentColorIndex = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Color currentColor = this.BackColor;
            Color nextColor = colors[currentColorIndex];
            AnimateBackgroundColor(currentColor, nextColor);
            currentColorIndex = (currentColorIndex + 1) % colors.Length;
        }

        private void AnimateBackgroundColor(Color startColor, Color endColor)
        {
            int animationSteps = 50;
            int animationDuration = 50;

            int rStep = (endColor.R - startColor.R) / animationSteps;
            int gStep = (endColor.G - startColor.G) / animationSteps;
            int bStep = (endColor.B - startColor.B) / animationSteps;

            for (int i = 0; i < animationSteps; i++)
            {
                int r = startColor.R + (rStep * i);
                int g = startColor.G + (gStep * i);
                int b = startColor.B + (bStep * i);

                Color intermediateColor = Color.FromArgb(r, g, b);

                this.BackColor = intermediateColor;

                Application.DoEvents();
                System.Threading.Thread.Sleep(animationDuration / animationSteps);
            }

            this.BackColor = endColor;
        }

    }
}