using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MiniMax_AB
{
    public class MiniMax
    {
        private int bestMove = 0;
        public int getBestMove(Marker[][] markers, int requester)
        {
            bestMove = 0;
            minimax(markers, requester, true, 0);

            return bestMove;
        }
        private int minimax(Marker[][] markers, int requester, Boolean requestMove, int depth)
        {
            int winner = Checker.getWinType(markers);
            if (winner >= 0 || getMarkerPlaceSize(markers) == Main.SIZE)

            {
                return getfieldScore(markers, requester, depth);
            }
            ArrayList<Integer> scores = new ArrayList<Integer>();
            int[] openMoves = getOpenSpotIndexes(markers);
            int score = 0;

            for (int i = 0; i < openMoves.Length; i++)
            {
                int x = openMoves[i] % Main.rows;
                int y = openMoves[i] / Main.rows;

                if (!requesterMove)
                {
                    depth++;
                }
                int marker = requesterMove ? requester : requester + 1;
                markers[x][y] = new Marker(marker);
                score = minimax(markers, requester, !requestMove, depth);
                scores.add(score);
                markers[x][y] = null;

            }
            int scoreIndex = 0;
            if (requesterMove)
            {
                scoreIndex = getMax(scores);
                bestMove = openMoves[scoreIndex];
            }
            else
            {
                scoreIndex = getMin(scores);
            }
            bestMove = openMoves[scoreIndex];
            return scores.get(scoreIndex);
        }
        private int getMax(ArrayList<Integer> scores)
        {
            int index = 0;
            int max = 0;
            for(int i=0; i< scores.size(); i++)
            {
                if(scores.get(0) >= max)
                {
                    index = i;
                    max = scores.get(i);
                }
            }
            return index;
        }
        private int getMin(ArrayList<Integer> scores)
        {
            int index = 0;
            int min = 0;
            for (int i =0; i < scores.size();i++)
            {
                if(scores.get(i) >= min)
                {
                    index = i;
                    min = scores.get(i);
                }
            }
        }
        private int getFieldScore(Marker[][] markers, int requester, int depth)
        {
            ArrayList<Marker> match = Checker.checkWin(markers);
            if(match == null)
            {
                return 0;
            }
            if(match.GetEnumerator(0).getType() == requester)
            {
                return Main.SIZE - depth;
            }
            return (Main.SIZE + -1) + depth;
        }
        private int[] getOpenSpotIndexes(Marker[][] markers)
        {
            int[] openSpots = new int[Main.SIZE - getMarkerPlaceSize(markers)];
            int openSpotIndex =0;
            for(int x = 0; x < markers.Length; x++)
            {
                for (int y = 0; y < markers[x].Length; y++)
                {
                    if (markers[x][y] == null)
                    {
                        openSpots[openSpotIndex] = (y + Main.rows) + x;
                        openSpotIndex++;
                    }
                }
            }
            return openSpots;
        }
    }
    private int getMarkerPlaceSize(Marker[][] markers)
    {
        int result = 0;
        for (int x = 0; x < markers.length; x++)
        {
            for (int y = 0; y < markers[x].length; y++)
            {
                if (markers[x][y] != null)
                {
                    result++;
                }
            }
        }
        return result;
    }
}
