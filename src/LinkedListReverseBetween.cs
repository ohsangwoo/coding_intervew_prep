using System;
using System.Collections.Generic;
public class LinkedListReverseBetween
{
    public static void Main(string[] args)
    {
        ListNode head = null;
        ListNode current = null;        
        var swapRangeFrom = int.Parse(args[0]);
        var swapRangeTo = int.Parse(args[1]);

        if(swapRangeFrom > args.Length -1 || swapRangeTo > args.Length || swapRangeFrom > swapRangeTo)
        {
            Console.WriteLine("Invalid range specified.");
            return;
        }
            
        

        for(var i = 2; i < args.Length; i++)
        {
            var newListNode = new ListNode(int.Parse(args[i]));
            if(current == null)
            {
                current = newListNode;
                head = current;
            } 
            else 
            {
                current.next = newListNode;
                current = current.next;
            }
        }
        
        PrintAllNodes(head);
        var solution = new Solution();
        var reversed = solution.reverseBetween(head, swapRangeFrom, swapRangeTo);
        PrintAllNodes(reversed);
    }

    private static void PrintAllNodes(ListNode head)
    {
        while(head != null)
        {
            var val = head == null ? "null" : $"{head.val}";
            Console.Write($"{val}");
            if(head.next != null)
            {
                Console.Write(" -> ");
            }

            head = head.next;
        }
        Console.WriteLine();
    }
}


class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) {this.val = x; this.next = null;}
}


class Solution
{
    public ListNode reverseBetween(ListNode A, int B, int C)
    {
        ListNode headNode = A;
        ListNode currentNode = A;
        ListNode Bp = null;
        ListNode Cp = null;

        if (B == C)
            return headNode;

        var i = 1;

        while (currentNode != null)
        {
            if (i + 1 == B)
            {
                Bp = currentNode;
            }

            if (i == C)
            {
                Cp = currentNode.next;
            }

            currentNode = currentNode.next;
            i++;
        }

        if (Bp == null)
        {
            return Reverse(headNode, Cp, C - B + 1);

        }
        else
        {
            Bp.next =  Reverse(Bp.next, Cp, C - B + 1);
        }
        

        return headNode;
    }

    //// Recursion
    //  private ListNode Reverse(ListNode currentNode, ListNode reversedNodeHeader, int numberOfNodes)
    //  {
    //      ListNode nextNode = currentNode.next;
    //      currentNode.next = reversedNodeHeader;

    //      if (numberOfNodes == 1)
    //      {
    //          return currentNode;
    //      }

    //      return Reverse(nextNode, currentNode, numberOfNodes - 1);
    // }

    //  Iterative
    private ListNode Reverse(ListNode currentNode, ListNode reversedNodeHeader, int numberOfNodes)
    {
        for(int i = 0; i < numberOfNodes; i++)
        {
            var nextNodeToReverse = currentNode.next;
            currentNode.next = reversedNodeHeader;
            reversedNodeHeader = currentNode;
            currentNode = nextNodeToReverse;
        }

        return reversedNodeHeader;
    }

}

