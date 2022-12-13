namespace Y2022.D13;

public abstract class Node
{
    public abstract override string ToString();
}

public class IntNode : Node
{
    public int Val { get; set; }

    public override string ToString()
    {
        return Val.ToString();
    }
}

public class ListNode : Node
{
    public List<Node> Val { get; set; }

    public override string ToString()
    {
        return $"[{string.Join(',', Val.Select(v => v.ToString()))}]";
    }
}

public static class NodeHelper
{
    public static Node Parse(ReadOnlySpan<char> input)
    {
        var items = new List<Node>();

        var i = 0;
        var inputEndIndex = input.Length;
        while (i < inputEndIndex)
        {
            var c = input[i];
            if (c == '[')
            {
                var inner = ReadArrayToEnd(input[i..]);
                items.Add(Parse(inner[1..^1]));
                i += inner.Length + 1; // Ignore comma
            }
            else
            {
                var number = ReadIntToEnd(input[i..]);
                i += number.Length + 1; // Ignore comma

                if (number.Length <= 0) continue;
                var intNode = new IntNode { Val = int.Parse(number) };
                items.Add(intNode);
            }
        }

        return new ListNode { Val = items };
    }

    private static ReadOnlySpan<char> ReadArrayToEnd(ReadOnlySpan<char> input)
    {
        var arrayLength = 1;
        var bracketCount = 1;
        while (bracketCount > 0)
        {
            var c = input[arrayLength];
            if (c is '[') bracketCount++;
            else if (c is ']') bracketCount--;
            arrayLength++;
        }

        return input[..arrayLength];
    }

    private static ReadOnlySpan<char> ReadIntToEnd(ReadOnlySpan<char> input)
    {
        var intLength = 0;
        while (intLength < input.Length && char.IsDigit(input[intLength]))
        {
            intLength++;
        }
        
        return input[..intLength];
    }
    
    public static int Compare(Node left, Node right)
    {
        if (left == right) return 0;

        if (left is IntNode lIntItem && right is IntNode rIntItem)
        {
            return CompareIntNodes(lIntItem, rIntItem);
        }

        var lListNode = CastToListNode(left);
        var rListNode = CastToListNode(right);

        var index = 0;
        while (index < lListNode.Val.Count)
        {
            if (index >= rListNode.Val.Count) return 1;

            var comparison = Compare(lListNode.Val[index], rListNode.Val[index]);
            if (comparison is not 0) return comparison;
            index++;
        }

        if (lListNode.Val.Count == rListNode.Val.Count) return 0;
        return -1;
    }

    private static ListNode CastToListNode(Node node)
    {
        if (node is not ListNode listNode)
        {
            listNode = new ListNode { Val = new List<Node> { node } };
        }

        return listNode;
    }

    private static int CompareIntNodes(IntNode lIntItem, IntNode rIntItem)
    {
        if (lIntItem.Val == rIntItem.Val) return 0;
        if (lIntItem.Val < rIntItem.Val) return -1;
        return 1;
    }
}