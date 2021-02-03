using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatrixTransformationtest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        Rectangle rect1;
        Rectangle rect2;



        struct GetMatrices
        {
            public double a;
            public double d;
            public double h;
            public double v;
        }


        GetMatrices matrices;
        public MainWindow()
        {
            InitializeComponent();

            rect1 = new Rectangle();
            rect1.Height = 80;
            rect1.Width = 90;
            rect1.Fill = Brushes.Red;

            Canvas.SetLeft(rect1, 30);
            Canvas.SetTop(rect1, 30);


            rect2 = new Rectangle();
            rect2.Height = 50;
            rect2.Width = 70;
            rect2.Fill = Brushes.Pink;

            Canvas.SetLeft(rect2, 20);
            Canvas.SetTop(rect2, 70);

            mcanvas.Children.Add(rect1);
            mcanvas.Children.Add(rect2);


            matrices = new GetMatrices();
            matrices = GetCTM(rect1, rect2);


            MessageBox.Show(matrices.a.ToString());

            //GetCTM(rect1, rect2);
        


        }

        double a = 0;
        double d = 0;
        double h = 0;
        double v = 0;

        private GetMatrices GetCTM(Rectangle rect1, Rectangle rect2)
        {

            //For first rect
           
            double a1 = Canvas.GetLeft(rect1);
            double b1 = Canvas.GetTop(rect1);

            //For second rect
            double a2 = Canvas.GetLeft(rect2);
            double b2 = Canvas.GetTop(rect2);



            //width and height of rect1

            double width1 = rect1.Width;
            double height1 = rect1.Height;


            //width and height of rect2

            double width2 = rect2.Width;
            double height2 = rect2.Height;


          

            double xfac = width1 / width2;
            double yfac = height1 / height2;


            Console.WriteLine(xfac + "," + yfac);


            
            double t_w2=0;           
            double t_h2=0;

           

            a = a1;
            d = b1;
              


            if (xfac <=1)
            {
                t_w2 = width2 / xfac;
                //h = Math.Abs(width2 + a2 - t_w1);

               

            }
            else if (xfac >= 1)
            {
                t_w2 = width2*xfac;
                //h = Math.Abs(width1 + a1 - t_w2);

               
            }

         

            if (yfac < 1)
            {
                t_h2 = height2/xfac;

              

            }
            else if (yfac > 1)
            {

                t_h2 = height2 * yfac;

               
            }

            h = t_w2;
            v = t_h2;


            matrices.a = a1;
            matrices.d = b1;
            matrices.h = t_w2;
            matrices.v = t_h2;

            return matrices;

        }

        private void btn_CTM_Click(object sender, RoutedEventArgs e)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Width = h;
            rectangle.Height = v;
            rectangle.Fill = Brushes.Brown;

            Canvas.SetLeft(rectangle, a);
            Canvas.SetTop(rectangle, d);
            mcanvas.Children.Add(rectangle);

        }
    }
}
