using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMax_AB
{
    public class AI implements IGameObject
    {
        private Minimax minimax;
    private Grid grid;

    public AI(Grid grid)
    {
        this.grid = grid;
        minimax = new MiniMax();
    }
    public void makeMove()
    {
        grid.placeMarker(MiniMax.getBestMove(grid.getMarkers(), grid.getTurn()))
    }
       @Override
            public void update(float deltaTime)
    {
        //
    }
       @Override
             public void render(Graphics2D graphicRender)
    {
        //
    }
 }

