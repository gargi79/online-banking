

namespace HelloWorld
{

    struct AngleStruct
    {
        public double angle { get; set; }

        public double AngleDegrees
        {
            get { return this.angle * 180.0 / System.Math.PI; }
            set { this.angle = value / 180 * System.Math.PI; }
        }

        public void ShowInfo()
        {
            System.Console.WriteLine("Angle in degrees = " + AngleDegrees.ToString());
            System.Console.WriteLine("Angle in radians = " + angle.ToString());

        }
    }

}