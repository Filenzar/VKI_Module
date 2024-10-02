using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Abstract_Factory
{
    public partial class Form1 : Form
    {
        private IShapeFactory currentFactory;
        private IShape selectedShape = null;

        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Add("Red Factory");
            comboBox1.Items.Add("Blue Factory");
            comboBox1.SelectedIndexChanged += OnFactoryChanged;


            comboBox2.Items.Add("Circle");
            comboBox2.Items.Add("Square");
            comboBox2.Items.Add("Triangle");
            comboBox2.SelectedIndexChanged += OnShapeChanged;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;
        }
        private void OnFactoryChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    currentFactory = new RedFactory();
                    break;
                case 1:
                    currentFactory = new BlueFactory();
                    break;
            }
            if (selectedShape != null)OnShapeChanged(sender, e);

            Invalidate();
        }
        private void OnShapeChanged(object sender, EventArgs e)
        {


            if (comboBox2.SelectedItem.ToString() == "Circle")
            {
                selectedShape = currentFactory.CreateCircle();
            }
            else if (comboBox2.SelectedItem.ToString() == "Square")
            {
                selectedShape = currentFactory.CreateSquare();
            }
            else if (comboBox2.SelectedItem.ToString() == "Triangle")
            {
                selectedShape = currentFactory.CreateTriangle();
            }
            else
            {
                throw new InvalidOperationException("Unknown shape");
            }

            Invalidate();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (selectedShape!= null) 
            {
                selectedShape.Draw(e.Graphics);
            }
        }
    }

    public interface IShape
    {
        void Draw(Graphics graphics);
    }

    public class Circle : IShape
    {
        private Color color;

        public Circle(Color color)
        {
            this.color = color;
        }

        public void Draw(Graphics graphics)
        {
            using (Brush brush = new SolidBrush(color))
            {
                graphics.FillEllipse(brush, 10, 10, 100, 100);
            }
        }
    }

    public class Square : IShape
    {
        private Color color;

        public Square(Color color)
        {
            this.color = color;
        }

        public void Draw(Graphics graphics)
        {
            using (Brush brush = new SolidBrush(color))
            {
                graphics.FillRectangle(brush, 10, 10, 100, 100);
            }
        }
    }

    public class Triangle : IShape
    {
        private Color color;

        public Triangle(Color color)
        {
            this.color = color;
        }

        public void Draw(Graphics graphics)
        {
            using (Brush brush = new SolidBrush(color))
            {
                Point[] points = {
                new Point(60, 10),
                new Point(10, 110),
                new Point(110, 110)
            };
                graphics.FillPolygon(brush, points);
            }
        }
    }
    public interface IShapeFactory
    {
        IShape CreateCircle();
        IShape CreateSquare();
        IShape CreateTriangle();
    }

    public class RedFactory : IShapeFactory
    {
        public IShape CreateCircle() => new Circle(Color.Red);
        public IShape CreateSquare() => new Square(Color.Red);
        public IShape CreateTriangle() => new Triangle(Color.Red);
    }

    public class BlueFactory : IShapeFactory
    {
        public IShape CreateCircle() => new Circle(Color.Blue);
        public IShape CreateSquare() => new Square(Color.Blue);
        public IShape CreateTriangle() => new Triangle(Color.Blue);
    }

}
