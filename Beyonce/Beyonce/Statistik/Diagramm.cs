using System;
using System.Collections.Generic;
public class Diagramm
{
    public Dictionary<string, double> values = new Dictionary<string, double>();
    public Diagramm() {
        values.Add("Deutschland", 13);
        values.Add("™sterreich", 200);

    }

    public virtual void draw() {
    }
}
