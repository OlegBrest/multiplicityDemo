using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multiplicityDemo
{
    class LSystem2D
    {
        string axiom = "";
        string state = "";
        int width = 1;
        int lendth = 10;
        double angle = 0;
        ValueTuple<string ,string> [] rules = new ValueTuple<string , string>[0];
        TurtleSharp t;


        public LSystem2D(TurtleSharp trtl, string axi, int w, int l, double a)
        {
            axiom = axi;
            state = axi;
            width = w;
            lendth = l;
            angle = a;
            t=trtl;
        }

        public void add_rules(params ValueTuple<string, string> [] _rules)
        {
            rules = _rules;
        }

        public void gen_path (int n_iter)
        {
            for (int i =0; i<n_iter;i++)
            {
                foreach (ValueTuple<string,string> vt in rules)
                {
                    state = state.Replace(vt.Item1, vt.Item2.ToLower());
                }
                state = state.ToUpper();
            }
        }

        public void draw_turtle(int startposX,int strartposY, double startangle)
        {
            t.Up();
            t.setpos(new Point(startposX, strartposY));
            t.seth(startangle);
            t.Down();
            foreach(char move in state)
            {
                if (move=='F')
                {
                    t.fd(lendth);
                }
                if (move == 'S')
                {
                    t.Up();
                    t.fd(lendth);
                    t.Down();
                }
                else if (move == '+')
                {
                    t.left(angle);
                }
                else if (move == '-')
                {
                    t.right(angle);
                }
            }
        }
    }
}
