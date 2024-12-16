
public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        if (value == Data)
        {
            // Do nothing; duplicate values are not allowed.
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left == null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right == null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2

        if (value == Data)
        {
            // Found the value
            return true;
        }
        else if (value < Data)
        {
            // Search in the left subtree
            if (Left == null)
                return false;
            return Left.Contains(value);
        }
        else
        {
            // Search in the right subtree
            if (Right == null)
                return false;
            return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4

        // Use recursion to determine the height of the tree
        int leftHeight = Left != null ? Left.GetHeight() : 0; // Height of left subtree
        int rightHeight = Right != null ? Right.GetHeight() : 0; // Height of right subtree

        // Return 1 + maximum of leftHeight and rightHeight
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
