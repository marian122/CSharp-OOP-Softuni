using SimpleSnake.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const int DefaultLength = 6;
        private const int DefaultX = 8;
        private const int DefaultY = 7;
        private List<Coordinate> snakeBody;
        private Direction direction;

        public Snake()
        {
            this.snakeBody = new List<Coordinate>();
            this.direction = Direction.Right;
            this.initializeBody();
        }

        public IReadOnlyCollection<Coordinate> Body => this.snakeBody.AsReadOnly();

        public Direction Direction { get; set; }

        public void Move()
        {
            
            Coordinate newHead = this.GetNewHeadCoordinate();

            this.snakeBody.Add(newHead);
            this.snakeBody.RemoveAt(0);
        }

        private Coordinate GetNewHeadCoordinate()
        {
            Coordinate snakeHead = this.snakeBody.Last();
            Coordinate newHeadCoorinates = new Coordinate(snakeHead.CoordinateX, snakeHead.CoordinateY);

            switch (direction)
            {
                case Direction.Right:
                    newHeadCoorinates.CoordinateX++;
                    break;
                case Direction.Left:
                    newHeadCoorinates.CoordinateX++;

                    break;
                case Direction.Down:
                    newHeadCoorinates.CoordinateY++;

                    break;
                case Direction.Up:
                    newHeadCoorinates.CoordinateX--;

                    break;

               
            }
            return newHeadCoorinates;
        }

        private void initializeBody()
        {
            int x = DefaultX;
            int y = DefaultY;

            for (int i = 0; i <= DefaultLength; i++)
            {
                this.snakeBody.Add(new Coordinate(x, y));
                x++;
            }
        }
    }
}
