namespace Algorithms;

public class QuickUnion // lazy approach
{
    // Each index represents an element, and the value at that index represents the root of the component to which that element belongs.
    private readonly int[] ids;

    public QuickUnion(int n)    // O(n)
    {
        if (n > 0)
        {
            ids = new int[n];
            for (int i = 0; i < n; i++)
            {
                ids[i] = i;
            }
        }
        else
            throw new ArgumentException("Number of elements must be greater than zero.", nameof(n));
    }

    public bool Connected(int p, int q) // O(n)
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
