/*Description:
This code defines a binary tree structure and provides methods to serialize and deserialize it using preorder traversal. The `Codec` class contains two methods: `Serialize`, which converts a binary tree into a string representation, and `Deserialize`, which reconstructs the binary tree from that string.
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
        List<string> result = new List<string>();

        void Preorder(TreeNode node)
        {
            if (node == null)
            {
                result.Add("null");
                return;
            }

            result.Add(node.val.ToString());
            Preorder(node.left);
            Preorder(node.right);
        }

        Preorder(root);
        return string.Join(",", result);
    }

    public TreeNode Deserialize(string data)
    {
        Queue<string> queue = new Queue<string>(data.Split(','));

        TreeNode BuildTree()
        {
            if (queue.Count == 0) return null;

            string val = queue.Dequeue();
            if (val == "null") return null;

            TreeNode node = new TreeNode(int.Parse(val));
            node.left = BuildTree();
            node.right = BuildTree();
            return node;
        }

        return BuildTree();
    }
}

/* Örnek Kullanım:
var codec = new Codec();

TreeNode tree = new TreeNode(1,
    new TreeNode(2),
    new TreeNode(3, new TreeNode(4), new TreeNode(5))
);

string serialized = codec.Serialize(tree);
Console.WriteLine("Serialized: " + serialized);

TreeNode deserializedTree = codec.Deserialize(serialized);
*/