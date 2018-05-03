using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverDealerOn
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string input;

            
            Point NEPoint = new Point();
            NEPoint = getPointFromInput("for the NE corner of the plain:");
            Grid g = new Grid(NEPoint);//Grid should be independent of Rover

            do
            {
                Point startingPoint = new Point();
                Console.WriteLine("Now Enter the starting point coords and direction in xyz format on the first line ");
                input = Console.ReadLine();
                startingPoint.X = Convert.ToInt16(input[0].ToString());
                startingPoint.Y = Convert.ToInt16(input[1].ToString());
                int direction = DirectionFromCharToInt(input[2]);
                Rover rover1 = new Rover(direction, startingPoint.X, startingPoint.Y, g);
                Console.WriteLine("On the second line enter the instructions to turn left or right (L and R) and forward (M) ex. LLMLMMLMLM or LLMRMLMRRRML");
                input = Console.ReadLine();
                rover1.processInstructionString(input);
                string results = rover1.getEndingPositionString();
                Direction endingDirection = (Direction)Convert.ToInt32(results[results.Length - 1].ToString());
                results = results.Substring(0, results.Length - 1) + endingDirection.ToString();
                Console.WriteLine(results);
            } while (input != "EXIT");
        }

        /*This was going to be the original way I was going to collect user data.  I was going to change the message based on which
          coords were being gathered and then get the z value separately, but I just decided to only use it to collect NE point since I 
          had already created the function*/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Point getPointFromInput(string msg)
        {
            Point P = new Point();
            int X;
            //Take in the first value and establish the size of the grid
            Console.WriteLine(String.Format("Please enter the first (X) coordinate {0}", msg));

            String Result = Console.ReadLine();// Read string from console

            while (!Int32.TryParse(Result, out X))
            {
                Console.WriteLine("Not a valid number, try again.");

                Result = Console.ReadLine();
            }
            P.X = Convert.ToInt32(Result);

            int Y;
            //Take in the first value and establish the size of the grid
            Console.WriteLine(String.Format("Please enter the second (Y) coordinate {0}", msg));
            String ResultY = Console.ReadLine();// Read string from console

            while (!Int32.TryParse(Result, out Y))
            {
                Console.WriteLine("Not a valid number, try again.");

                ResultY = Console.ReadLine();
            }

            P.Y = Convert.ToInt32(ResultY);
            return P;
        }

        //function that can be used to quickly validate a char input as a valid direction (or z value)
        public static bool validDirection(char dir)
        {
            switch (Char.ToUpper(dir))
            {

                case 'N':
                case 'S':
                case 'W':
                case 'E':
                    return true;
                default:
                    return false;
            }
        }

        public enum Direction
        {
            N = 0,
            E = 1,
            S = 2,
            W = 3
        };

        public static int DirectionFromCharToInt(Char c)
        {
            Direction direction = new Direction();
            switch (Char.ToUpper(c))
            {
                case 'N':
                    direction = Direction.N;
                    break;
                case 'S':
                    direction = Direction.S;
                    break;
                case 'E':
                    direction = Direction.E;
                    break;
                case 'W':
                    direction = Direction.W;
                    break;
            }
            return (int)direction;
        }
    }
}


