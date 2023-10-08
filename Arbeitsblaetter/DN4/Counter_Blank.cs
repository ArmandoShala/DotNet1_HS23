/// <summary> A counter for accumulating values and computing the mean value.</summary>
class Counter_Blank {
    /// <summary>The accumulated values</summary>
    private int value;
	
    /// <summary>The number of added values</summary>
    public int n;
	
    /// <summary>Adds a value to the counter</summary>
    /// <param name="x">The value to be added</param>
    public void Add(int x) {
        value += x; n++;
    }
	
    /// <summary>Returns the mean value of all accumulated values</summary>
    /// <returns>The mean value, i.e. <see cref="value"/> / <see cref="n"/></returns>
    public float Mean() {
        return (float)value / n;
    }
}