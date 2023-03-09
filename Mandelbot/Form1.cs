namespace Mandelbot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // fractal.- figura que se repite en baja y alta escala.
        //formula para sacar el conjunto de mandelbrot.- Zk+1=Zk2+C 
        //
        private void Form1_Load(object sender, EventArgs e)
        {
            //creamos una funcion
            MandelbrotSet();
        }
        //Creamos el metodo
        private void MandelbrotSet()
        {
            //Sacamos el ancho y alto del pictureBox
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            //se crea un bitmap donde se va arepresentar la imagen, con elancho y alto del pictureBox
            Bitmap bmp = new Bitmap(width, height);
            //se recorre el pictureBox por filas de arriba a abajo
            for (int row = 0; row < height; row++)
            {
                //se hace lo mismo con las columnas
                for (int col = 0; col < width; col++)
                {
                    //tenemos que encontrar el centro, el conjunto de maldelbrot tiene una diametro de 4
                    double c_re = (col - width / 2.0) * 4.0 / width;
                    double c_im = (row - height / 2.0) * 4.0 / height;
                    int iteracion = 0;
                    double x = 0;
                    double y = 0;
                    while (iteracion < 1000 && ((x * x) + (y * y)) <= 4)
                    {
                        double x_temp = (x * x) - (y * y) + c_re;
                        y = 2 * x * y + c_im;
                        x = x_temp;
                        iteracion++;

                    }
                    if (iteracion < 1000)
                    {
                        bmp.SetPixel(col, row, Color.FromArgb(iteracion % 2, iteracion % 40 * 5, iteracion % 112));
                    }
                    else
                        bmp.SetPixel(col, row, Color.Black);
                }
            }
            pictureBox1.Image = bmp;
        }
    }
}