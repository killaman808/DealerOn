using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverDealerOn
{
    public class Rover
    {
        private int x = 0, y = 0;
        private int direction;
        private IGrid _igrid;//using interface here will inject implemented Grid later for dependency injection
        
        //I am thinking that I need to pass in the direction when the Rover is instantiated
        public Rover(int dir, int startX, int startY, IGrid igrid)//
        {
            direction = dir;
            x = startX;
            y = startY;
            _igrid = igrid;
        }

        public int maxX { get; set; }
        public int maxY { get; set; }

        public void processInstructionString(string instructions)
        {
            for (int i = 0; i < instructions.Length; i++)
            {
                char move = instructions[i];
                MoveRover(move);
            }
        }

        public string getEndingPositionString()
        {
            StringBuilder endingPosition = new StringBuilder();
            endingPosition.Append(x.ToString()).Append(y.ToString()).Append(direction.ToString());
            return endingPosition.ToString();
        }

        //This function tracks the xyz coords as input chars are passed in
        //Valid inputs are L, R, and M.  L and R change the direction the rover is facing (or z coord) and M
        //moves the rover forward in whatever direction it is facing.  If at any time the rover leaves the grid
        //a custom roveroutofbounds exception 
        public void MoveRover(char moveInput)
        {
            // If move is left or right, then change direction
            if (moveInput == 'R')
                direction = (direction + 1) % 4;
            else if (moveInput == 'L')
                direction = (4 + direction - 1) % 4;
            // Of move is M change x or y
            else if (moveInput == 'M')
            {
                if (direction == 0)
                {
                    y++;
                    if (y > _igrid.maxY)
                    {
                        throw new RoverOutOfBoundsException("Rover out of Bounds");
                    }
                }
                else if (direction == 1)
                {
                    x++;
                    if (x > _igrid.maxX)
                    {
                        throw new RoverOutOfBoundsException("Rover out of Bounds");
                    }
                }
                else if (direction == 2)
                {
                    y--;
                    if (y < 0)
                    {
                        throw new RoverOutOfBoundsException("Rover out of Bounds");
                    }
                }
                else // dir == 3
                {
                    x--;
                    if (x < 0)
                    {
                        throw new RoverOutOfBoundsException("Rover out of Bounds");
                    }
                }
            }
        }
    }
}
