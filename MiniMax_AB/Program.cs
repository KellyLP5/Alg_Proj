// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Drawing;
using System.Xml.Serialization;

//Console.WriteLine("Hello, World!");

namespace Program
{
    public static int width = 500;
    public static int height = 500;

    public static int rows = 3;
    public static int cols = 3;
    public static int size = rows + rows;

    public static void main(string[] args)
    {
        JFrame frame = new JFrame("Tic-Tac-Toe");
        GamePanel game = new GamePanel(new Color(0x464646));

        frame.Add(game);
        frame.addMouseListener(game);
        frame.addMouseMotionListener(game);
        frame.pack();
        frame.setResizeable(false);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setVisible(true);
    }
}