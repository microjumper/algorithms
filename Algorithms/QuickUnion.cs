namespace Algorithms;

public class QuickUnion // lazy approach
{
    // Each index represents an element, and the value at that index represents the root of the component to which that element belongs.
    private readonly int[] ids;

    // Used to keep track of the size of each component for weighted union.
    private readonly int[] sizes;

    public QuickUnion(int n)    // O(n)
    {
        if (n > 0)
        {
            ids = new int[n];
            sizes = new int[n];

            for (int i = 0; i < n; i++)
            {
                ids[i] = i;
                sizes[i] = 1;
            }
        }
        else
            throw new ArgumentException("Number of elements must be greater than zero.", nameof(n));
    }

    public bool Connected(int p, int q) // O(n), O(long(n)) if WeightedUnion is used
    {
        ValidateIndex(p);
        ValidateIndex(q);

        return RootOf(p) == RootOf(q);  // Two elements are connected if they have the same root.
    }

    public void Union(int p, int q) // O(n)
    {
        ValidateIndex(p);
        ValidateIndex(q);

        ids[RootOf(p)] = RootOf(q); // Connect the root of p to the root of q, merging the two components.
    }

    public void WeightedUnion(int p, int q) // O(log(n))
    {
        ValidateIndex(p);
        ValidateIndex(q);

        int rootP = RootOf(p);
        int rootQ = RootOf(q);

        if (rootP != rootQ)
        {
            if (sizes[rootP] < sizes[rootQ])
            {
                ids[rootP] = rootQ;
                sizes[rootQ] += sizes[rootP];
            }
            else
            {
                ids[rootQ] = rootP;
                sizes[rootP] += sizes[rootQ];
            }
        }
    }

    private int RootOf(int element) // O(n)
    {
        while (ids[element] != element)
        {
            element = ids[element];
        }

        return element;
    }

    private void ValidateIndex(int index)
    {
        if (index < 0 || index >= ids.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index must be within the valid range.");
        }
    }
}
