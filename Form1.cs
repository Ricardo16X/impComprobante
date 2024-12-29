using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
// LIBRERIAS DE GENERACION DE PDF
// LIBRERIAS OCR
using Tesseract;
// LIBRERIAS LIMPIEZA DE IMAGENES
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Text;
using System.Text.RegularExpressions;

namespace Impresora_Comprobantes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            // FORMATEO DE TEXTO.
            StringBuilder sb = new StringBuilder();
            // REGEX para identificar etiquetas y valores.
            string[] lista = tmpTxt.Text.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            string etiquetaActual = null;
            int maxL = 0;
            foreach (string linea in lista)
            {
                if (linea.Contains(":"))
                {
                    string tmpL = linea.Split(':')[0] + ":";
                    if (tmpL.Length > maxL) maxL = tmpL.Length;
                }
            }
            // FORMATEO DE LINEAS.
            foreach (string linea in lista)
            {
                if (linea.Contains(":"))
                {
                    
                }
            }
            tmpTxt.Clear();
            tmpTxt.Text = sb.ToString();
        }

        private void reprocesoImagen(Image image)
        {
            Bitmap btmp = new Bitmap(image);
            Mat imgT = BitmapConverter.ToMat(btmp);
            // REDIMENSIONAMIENTO DE IMAGEN.
            Mat imgRsd = new Mat();
            Cv2.Resize(imgT, imgRsd, new OpenCvSharp.Size(), 2, 2, InterpolationFlags.Cubic);
            // ESCALA DE GRISES DE IMAGEN.
            Mat imgGris = new Mat();
            Cv2.CvtColor(imgRsd, imgGris, ColorConversionCodes.BGR2GRAY);
            // BINARIZACION DE IMAGEN.
            Mat imgBin = new Mat();
            Cv2.Threshold(imgGris, imgBin, 0, 255, ThresholdTypes.Binary | ThresholdTypes.Otsu);
            // ELIMINACION DE RUIDO EN IMAGEN.
            Mat imgRuido = new Mat();
            Cv2.GaussianBlur(imgBin, imgRuido, new OpenCvSharp.Size(5, 5), 0);
            // AJUSTE DE CONTRASTE Y BRILLO EN IMAGEN.
            Mat imgCorr = new Mat();
            imgRuido.ConvertTo(imgCorr, MatType.CV_8U, 1.5, 0);
            // GUARDADO DE IMAGEN.
            Cv2.ImWrite(".\\temp_image.png", imgCorr);
        }

        private void obtenerTexto()
        {
            string rutaBase = AppDomain.CurrentDomain.BaseDirectory;
            string rutaTessdata = Path.Combine(rutaBase, "tessdata");
            var engine = new TesseractEngine(rutaTessdata, "spa", EngineMode.Default);
            // engine.SetVariable("preserve_interword_spaces", "1");
            engine.DefaultPageSegMode = PageSegMode.Auto;

            rutaTessdata = Path.Combine(rutaBase, "temp_image.png");
            var img = Pix.LoadFromFile(rutaTessdata);
            var page = engine.Process(img);
            var text = page.GetIterator();
            text.Begin();
            do
            {
                if (text.IsAtBeginningOf(PageIteratorLevel.TextLine))
                {
                    if (text.GetText(PageIteratorLevel.TextLine) != " \n\n")
                    {
                        tmpTxt.AppendText(text.GetText(PageIteratorLevel.TextLine));
                        tmpTxt.AppendText("\r\n");
                    }
                }
            } while (text.Next(PageIteratorLevel.TextLine));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                if (Clipboard.ContainsImage())
                {
                    tmpTxt.Clear();
                    imgVisualizador tmpForm = new imgVisualizador(this);
                    tmpForm.Show();
                    reprocesoImagen(Clipboard.GetImage());
                    obtenerTexto();
                }
                else
                {
                    if (!tmpTxt.Focused) MessageBox.Show("No hay imagen en el portapapeles");
                }
            }
        }
    }
}
