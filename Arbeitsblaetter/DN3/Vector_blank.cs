namespace DN3 {
    public struct Vector_Blank {
        double x,y,z; 
        //Konstruktor
        public Vector_Blank(double x, double y, double z){
            this.x=x;
            this.y=y;
            this.z=z;
        }

        public override string ToString(){
            return "["+x+" "+y+" "+z+"]";
        }

        public static Vector operator *(Vector a, Vector b) =>
            new (a.y * b.z - a.z * b.y
                , a.z * b.x - a.x * b.z
                , a.x * b.y - a.y * b.x);
    }

    internal class MainClass_Blank {
       public static void Test() {
          Vector a = new Vector(1,2,3);
          Vector b = new Vector(4,5,6);
          Vector c = a * b;
          Console.WriteLine(c);
        }

        public static void Main_Blank(string[] args) {
           Test();
        }
    }
}
