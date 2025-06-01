/*Description:
This code defines a binary tree structure and provides methods to serialize and deserialize it using level-order traversal. The `Codec` class contains two methods: `Serialize`, which converts a binary tree into a string representation, and `Deserialize`, which reconstructs the binary tree from that string. The serialization uses a queue to traverse the tree level by level, while deserialization reconstructs the tree based on the serialized string.
*/

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Codec
{
    public string Serialize(TreeNode root)
    {
        if (root == null) return "null";

        Queue<TreeNode> queue = new Queue<TreeNode>();
        List<string> result = new List<string>();

        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();

            if (node == null)
            {
                result.Add("null");
                continue;
            }

            result.Add(node.val.ToString());
            queue.Enqueue(node.left);
            queue.Enqueue(node.right);
        }

        return string.Join(",", result);
    }

    public TreeNode Deserialize(string data)
    {
        if (data == "null") return null;

        string[] values = data.Split(',');
        TreeNode root = new TreeNode(int.Parse(values[0]));
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        int i = 1;
        while (queue.Count > 0 && i < values.Length)
        {
            TreeNode current = queue.Dequeue();

            if (values[i] != "null")
            {
                current.left = new TreeNode(int.Parse(values[i]));
                queue.Enqueue(current.left);
            }
            i++;

            if (i < values.Length && values[i] != "null")
            {
                current.right = new TreeNode(int.Parse(values[i]));
                queue.Enqueue(current.right);
            }
            i++;
        }

        return root;
    }
}

/* Örnek kullanım:
var codec = new Codec();

TreeNode tree = new TreeNode(1,
    new TreeNode(2),
    new TreeNode(3, new TreeNode(4), new TreeNode(5))
);

string serialized = codec.Serialize(tree);
Console.WriteLine("Serialized: " + serialized);

TreeNode deserializedTree = codec.Deserialize(serialized);
*/