
namespace drawingApp
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Drawing;
    using System.Collections;

    [Serializable]

    public abstract class ribb
    {
        // privates:
       
        protected int size;
        protected int x;
        protected int y;

        // get's and set's:

        public int Size  // property
        {
            get { return size; }   // get method
            set { size = value; }  // set method
        }

        public int X  // property
        {
            get { return x; }   // get method
            set { x = value; }  // set method
        }

        public int Y // property
        {
            get { return y; }   // get method
            set { y = value; }  // set method
        }

        // Abstract methods:

        public abstract void Draw(Graphics g, Pen pen , int pX, int pY);
    }

    [Serializable]
    class  circle: ribb
    {
        protected float radius;

        public circle()
         : this(5) { }

        public circle(float rad)
        {
            radius = rad;
            X = 0;
            Y = 0;
            Size = 1; // how much tszlaot in shape
        }

        public circle(circle s)
        {
            this.radius = s.radius;
            this.X = s.X;
            this.Y = s.Y;   
        }

        public float Radius // property
        {
            get { return radius; }   // get method
            set { radius = value; }  // set method
        }

        public override void Draw(Graphics g, Pen pen, int pX, int pY)
        {
            X = pX;
            y = pY;
            //Pen pen = new Pen(Color.Black, 5);
            g.DrawEllipse(pen, X - radius, Y - radius, radius * 2, radius * 2);
        }

      
    }

    [Serializable]
    class equalRibbedTriangle:ribb
    {
        // Privates:

        protected int height;

        // Constructors:

        public equalRibbedTriangle()
            : this(10) { }

        public equalRibbedTriangle(int height)
        {
            this.height = height;
            X = 2;
            Y = 2;
            Size = 3;
        }

        public equalRibbedTriangle(equalRibbedTriangle s)
        {
            this.Y = s.Y;
            this.X = s.X;
            this.height = s.height;
        }

        // float height get and set:

        public int Height
        {
            get { return height; }
            set { height = value; } 
        }

        // Draw overriding:

        public override void Draw(Graphics g, Pen pen, int pX, int pY)
        {
            X = pX;
            y = pY;
            g.DrawLine(pen, X, Y, X + height, Y + height);
            g.DrawLine(pen, X + height, Y + height, X, Y + height * 2);
            g.DrawLine(pen, X, Y + height * 2, X, Y);
        }
    }


    [Serializable]
    class square : ribb
    {
        // Privates:

        protected int height;

        // Constructors:

        public square()
            : this(10) { }

        public square(int height)
        {
            this.height = height;
            X = 0;
            Y = 0; 
            Size = 4;
        }


        public square(square s)
        {
            this.Height = s.Height;
            this.X = s.X;
            this.Y = s.Y;   
        }

        // height get and set:

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        // Draw overriding:

        public override void Draw(Graphics g, Pen pen, int pX, int pY)
        {
            X = pX;
            Y = pY;
            g.DrawRectangle(pen, X, Y, height, height);
        }
    }

    [Serializable]

    class meuyan:square
    {
        // privates:

        protected int width;

        // constructors:

        public meuyan()
            : this(150, 50) { }

        public meuyan(int height, int width)
        {
            Height = height;
            this.width=width;
        }

        public meuyan(meuyan s)
        {
          this.Height = s.Height;
          this.width = s.width;
          this.X = s.X;
          this.Y = s.Y;
        }

        // get and set:
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        // function overriding:

        public override void Draw(Graphics g, Pen pen, int pX, int pY)
        {
            X = pX;
            Y = pY;
            g.DrawLine(pen, X, Y, X + width * 2, Y + Height);
            g.DrawLine(pen, X , Y , X + width * 2, Y - height);
            g.DrawLine(pen, X + width * 4, Y , X + width * 2, Y + Height  );
            g.DrawLine(pen, X + width * 2, Y - height, X + width * 4, Y);
        }
    }

    [Serializable]
    class rectangle:square
    {
        // Privates:

        protected int width;

        // Constructors:

        public rectangle()
            : this(10, 20) { }

        public rectangle(int height, int width)
        {
            this.Height = height;
            this.width = width;
            X = 5;
            Y = 5;
            Size = 4;
        }

        public rectangle(rectangle s)
        {
            this.Height = s.Height;
            this.width = s.width;
            this.X = s.X;
            this.Y = s.Y;
        }

        // height get and set:

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        // Draw overriding:

        public override void Draw(Graphics g, Pen pen, int pX, int pY)
        {
            X = pX;
            y = pY;
            g.DrawRectangle(pen, X, Y, Height, width);
        }
    }

    [Serializable]
    class makbilit : rectangle
    {
        // Privates:

        protected int diagonal;

        // Constructors:

        public makbilit()
            : this(10, 20, 5) { }

        public makbilit(int height, int width, int diagonal)
        {
            this.Height = height;
            this.Width = width;
            this.diagonal = diagonal;
            X = 5;
            Y = 5;
            Size = 4;
        }

        public makbilit(makbilit s)
        {
            this.Height = s.Height;
            this.Width = s.Width;
            this.diagonal = s.diagonal;
            this.X = s.X;
            this.Y = s.Y;
        }
        // height get and set:

        public int Diagonal
        {
            get { return diagonal; }
            set { diagonal = value; }
        }

        // Draw overriding:

        public override void Draw(Graphics g, Pen pen, int pX, int pY)
        {
            X = pX;
            y = pY;
            g.DrawLine(pen, X, Y, X + diagonal, Y + Height);
            g.DrawLine(pen, X + diagonal, Y + Height, X + diagonal + Width, Y + Height);
            g.DrawLine(pen, X + diagonal + Width, Y + Height, X + 2 * diagonal + Width, Y);
            g.DrawLine(pen, X + 2 * diagonal + Width, Y, X, Y);
        }
    }


    [Serializable]
    public class FigureList // Create SortedList to serialize
    {
        protected SortedList figures;

        public FigureList()
        {
            figures = new SortedList();
        }
        public int NextIndex
        {
            get
            {
                return figures.Count;
            }
        }
        public ribb this[int index]
        {
            get
            {
                if (index >= figures.Count)
                    return (ribb)null;
                return (ribb)figures.GetByIndex(index);
            }
            set
            {
                if (index <= figures.Count)
                    figures[index] = value; 		
            }
        }
    }
}




