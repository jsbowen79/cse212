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
        if (this.Contains(value))
        {
            return;
        }

        else if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        if (value < Data)
        {
            if (Left is null)
            {
                return false;
            }
            else if (Left.Data == value)
            {
                return true;
            }
            else
            {
                if (Left.Contains(value))
                {
                    return true;
                }
                ;
            }
        }
        else if (value == Data)
        {
            return true;
        }
        else
        {
            if (Right is null)
            {
                return false;
            }
            else if (Right.Data == value)
            {
                return true;
            }
            else
            {
                if (Right.Contains(value))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public int GetHeight()
    {
        int rightHeight = 0;
        int leftHeight = 0;

        int Height(Node node, string direction)
        {
            if (direction == "Right")
            {
                if (node.Right != null)
                {
                    rightHeight = 1 + Height(node.Right, "Right");
                }
                return rightHeight;
            }
            else if (direction == "Left")
            {
                if (node.Left != null)
                {
                    leftHeight = 1 + Height(node.Left, "Left");
                }
                return leftHeight;
            }
            return 0;
        }
        if (this.Right == null && this.Left == null)
        {
            return 1;
        }

        else if (this.Right != null) {
            rightHeight = 1 + Height(this, "Right");
        }
        else if (this.Left != null)
            {
                leftHeight = 1 + Height(this, "Left");
            }
            return Math.Max(rightHeight, leftHeight);
    }
}

