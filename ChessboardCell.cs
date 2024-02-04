﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class ChessboardCell
    {
        public int x, y;
        public static byte count = 0;
        //если программист не создал ни одного конструктора или какие-то поля не были проинициализированы, то полям значимых типов присваиваются 0, ссылочным - null
        //если у нас есть прописанный констроктор в классе, то конструктор по умолчанию уже не работает, его нужно явно прописывать


        //свойства
        public int X
        {
            get => x;
            set
            {
                if (value < 1 || value > 8)
                {
                    throw new Exception("Координата клетки должна быть от 1 до 8"); //применили исключения в свойствах, 
                }
                else x = value;
            }
        }
        public int Y
        {
            get => y;
            set
            {
                if (value < 1 || value > 8)
                {
                    throw new Exception("Координата клетки должна быть от 1 до 8");
                }
                else y = value;
            }
        }
        //свойства end

        //конструкторы
        public ChessboardCell() // конструктор по умолчанию 
        {
            x = 1;
            y = 1;
            count++;
        }
        
        public ChessboardCell(int x, int y) //конструктор с параметром
        {
            Y = y;
            X = x;
            count++;
        }

        public ChessboardCell(ChessboardCell ch) //конструктор копирования
        {
            Y = ch.y;
            X = ch.x;
            count++;
        }
        //конструкторы end

        //методы
        public static bool Same(ChessboardCell cell1, ChessboardCell cell2) //проверка, являются ли клетки одного цвета
        {
            return (cell1.x + cell1.y) % 2 == (cell2.x + cell2.y) % 2;
        }
        public bool BlackOrWhite(ChessboardCell cell1, ChessboardCell cell2)
        {
            return (cell1.x + cell1.y) % 2 == (cell2.x + cell2.y) % 2;
        }

        public void Show()
        {
            Console.WriteLine($"По горизонтали: {X} по вертикали: {Y}");
        }
        //методы end

        //перегрузка
        public static ChessboardCell operator ++(ChessboardCell cell) //увеличение каждой координаты на 1
        {
            if (cell.x == 8 || cell.y == 8)
            {
                Console.WriteLine("Операция невозможна, координата клетки должна быть от 1 до 8");
                return cell;
            }
            ChessboardCell result = new ChessboardCell(cell);
            result.x = result.x + 1;
            result.y = result.y + 1;
            return result;
        }

        public static ChessboardCell operator !(ChessboardCell cell)
        {
            if (cell.x == cell.y)
                return cell;
            else
            {
                ChessboardCell result = new ChessboardCell();
                result.x = cell.y;
                result.y = cell.x;
                return result;
            }
        }

        public static explicit operator int(ChessboardCell cell)
        {
            return cell.x + cell.y;
        }

        public static implicit operator string(ChessboardCell cell)
        {
            if ((cell.x + cell.y) % 2 == 0)
                return "Черная клетка";
            else return "Белая клетка";
        }

        public static bool operator ==(ChessboardCell cell1, ChessboardCell cell2)
        {
            if (Math.Abs(cell1.x - cell2.x) + Math.Abs(cell1.y - cell2.y) == 3)
                return true;
            else return false;
        }

        public static bool operator !=(ChessboardCell cell1, ChessboardCell cell2)
        {
            if (cell1.x != cell2.x)
                return true;
            else return false;
        }

        //перегрузка end 
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not ChessboardCell) return false;
            return ((ChessboardCell)obj).x == this.x && ((ChessboardCell)obj).y == this.y;
        }
    }
}
