using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMax_AB
{
    public Marker(int x, int y, int type)
    {
        this.x = x;
        this.y = y;

        this.type = type % 2;
        String markerType = this.type == 0 ? "x" : "o";

        try
        {
            marker = ImageIO.read(new File("assets/" + markerType + ".prg"));
        }
        catch(Exception e)
        {
            e.printStackTrace();
        }
    }
    public Marker(int marker)
    {
        this.type = type % 2;
    }
    @Override

}
