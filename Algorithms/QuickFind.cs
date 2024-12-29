namespace Algorithms;

/* 
 * The QuickFind algorithm's Union operation has O(N) time complexity. It requires scanning the entire array 
 * to update the component IDs of all elements connected to the first element in the union. As a result, performing
 * N Union operations on N elements results in O(N^2) total array accesses, making QuickFind inefficient for large datasets
 * with many union operations. 
 */

public class QuickFind  // eager approach
{
    // The array acts as a way to track which component each element belongs to
    private readonly int[] ids;

    public QuickFind(int n) // O(n)
    {
        if (n > 0)
        {
            ids = new int[n];

            for (int i = 0; i < n; i++)
            {
                ids[i] = i; // Each element is in its own component
            }
        }
        else
            throw new ArgumentException("Number of elements must be greater than zero.", nameof(n));
    }

    public bool Connected(int p, int q) // O(1)
    {
        ValidateIndex(p);
        ValidateIndex(q);

        return ids[p] == ids[q];
    }

    public void Union(int p, int q) // O(n)
    {
        ValidateIndex(p);
        ValidateIndex(q);

        int pId = ids[p];
        int qId = ids[q];

        // If an element is in the same component as `p`, it changea its component ID to `qId`.
        for (int i = 0; i < ids.Length; i++)
        {
            if (ids[i] == pId)
            {
                ids[i] = qId;
            }
        }
    }

    private void ValidateIndex(int index)
    {
        if (index < 0 || index >= ids.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index must be within the valid range.");
        }
    }
}
