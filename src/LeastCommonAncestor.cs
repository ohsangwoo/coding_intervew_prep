public class LeastCommonAncestor
{
    public static void Main(string[] args)
    {
        var solution = new Solution();

        TreeNode root = null;
        TreeNode curentNode = root;
        
        InsertNode(root, currentNode, 0, args);
        
        
        // for(var i = 0; i < args.Length; i++)
        // {   
        //     Solution.InsertNode(root, index, val);
        //     index++;
        // }

    }
    
}

class Solution {
    public TreeNode InsertNode(TreeNode root, TreeNode currentNode, int count, string[] val)
    {
        if(val.Length == count)
        {
            return root;
        }

        if(count == 0)
        {
            root = new TreeNode(int.Parse(val));
            currentNode = root;
        }

        currentNode.left(InsertNode(root, currentNode, count+1, val));
        currentNode.right(InsertNode(root, currentNode, count+2, val));
            
        

    }
    public int lca(TreeNode A, int B, int C) {
        if( hasNode(A.left, B) )
        {
            if(hasNode(A.right, C)){
                return A.val;
            } 
            else if(hasNode(A.left, C))
            {
                return lca(A.left, B, C);
            }
        } else if(hasNode(A.right, B))
        {
            if(hasNode(A.left, C)){
                return A.val;
            }    
            else if(hasNode(A.right, C))
            {
                return lca(A.right, B, C);
            }
        }
        
        return -1;
        
    }
    
    private bool hasNode(TreeNode t, int val)
    {
        if(t == null)
        {
            Console.WriteLine($"null");
            return false;
        }
            
        Console.WriteLine($"{t.val}");
            
        if(t.val == val)
            return true;
        
        return hasNode(t.left, val) || hasNode(t.right, val);
    }
}

class TreeNode {
     public int val;
     public TreeNode left;
     public TreeNode right;
     public TreeNode(int x) {this.val = x; this.left = this.right = null;}
 }
 